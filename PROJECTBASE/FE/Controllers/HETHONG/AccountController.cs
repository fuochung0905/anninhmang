using FE.Constants;
using FE.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace FE.Controllers.HETHONG
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [AllowAnonymous]
        public IActionResult LoginPortal()
        {
            return View("~/Views/Account/LoginPortal.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<JsonResult> Login(string UserName, string Password)
        {
            try
            {
                var request = new LoginRequest { Password = Password, UserName = UserName };
                if (request != null && ModelState.IsValid)
                {
                    ResponseData response = this.LoginAPI(URL_API.TAIKHOAN_LOGIN, request);
                    if (response.Status)
                    {
                        var taikhoanData = JsonConvert.DeserializeObject<MODELTaiKhoanPhanQuyen>(response.Data.ToString());
                        var userData = taikhoanData.TaiKhoan;

                        var claims = new List<Claim>();
                        HttpContext.Session.SetString("fullRole", JsonConvert.SerializeObject(taikhoanData.PhanQuyen));
                        HttpContext.Session.SetString("menu", JsonConvert.SerializeObject(taikhoanData.Menu));

                        claims.Add(new Claim("nhomQuyen", JsonConvert.SerializeObject(taikhoanData.NhomQuyen)));
                        claims.Add(new Claim("userId", userData.Id.ToString()));
                        claims.Add(new Claim("VaiTroId", userData.VaiTroId.ToString()));
                        claims.Add(new Claim(ClaimTypes.Name, userData.UserName));
                        claims.Add(new Claim(ClaimTypes.Surname, userData.HoLot));
                        claims.Add(new Claim(ClaimTypes.GivenName, userData.Ten));
                        if (!string.IsNullOrEmpty(userData.AnhDaiDien))
                        {
                            claims.Add(new Claim(ClaimTypes.Thumbprint, userData.AnhDaiDien));
                        }
                        claims.Add(new Claim("Token", userData.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        return Json(new { IsSuccess = true, Message = "", Data = "" });
                    }
                    else
                    {
                        throw new Exception(response.Message);
                    }
                }
                else
                {
                    throw new Exception(CommonFunc.GetModelState(this.ModelState));
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message, Data = "" });
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

        #region FUNCTION
        private ResponseData LoginAPI(string action, object model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsJsonAsync(action, model);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CommonFunc.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }
            return response;
        }

        private ResponseData ExecuteAPIResponse(Task<HttpResponseMessage> responseTask)
        {
            ResponseData response = new ResponseData();

            //To store result of web api response.   
            var result = responseTask.Result;

            //CHECK 401
            //if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //{
            //    HttpContext.SignOutAsync().Wait();
            //    RedirectToAction("Index", "Login").ExecuteResultAsync(this.ControllerContext).Wait();
            //}

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                if (readTask == null)
                {
                    response.Status = false;
                    response.Message = "Lỗi hệ thống";
                }
                else
                {
                    string json = readTask.Result;
                    var resultData = JsonConvert.DeserializeObject<MODELAPIBasic>(json);

                    response.Message = resultData.Message;
                    if (!resultData.Success || resultData.StatusCode != Convert.ToInt32(MODELS.COMMON.StatusCode.Success))
                    {
                        response.Status = false;
                    }
                    else
                    {
                        response.Data = resultData.Result;
                    }
                }
            }
            else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                response.Status = false;
                response.Message = "Phần mềm chưa đăng ký bản quyền hoặc hết hạn bản quyền";
            }
            else
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống";
            }

            return response;

        }

        private string GetBEUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
        }
        #endregion
    }
}
