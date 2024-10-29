using FE.Constants;
using FE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MODELS.BASE;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.Http.Headers;


namespace FE.Controllers
{
    [CustomAuthorizeAttribute]
    public class BaseController<T> : Controller
    {
        public BaseController()
        {

        }

        public MODELPhanQuyen GetPhanQuyen()
        {
            List<MODELPhanQuyen> fullRole = new List<MODELPhanQuyen>();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("fullRole")))
            {
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETPHANQUYEN, new { UserId = GetUserId() });
                if (response.Status)
                {
                    HttpContext.Session.SetString("fullRole", response.Data.ToString());
                    fullRole = JsonConvert.DeserializeObject<List<MODELPhanQuyen>>(response.Data.ToString());
                }
            }
            else
            {
                fullRole = JsonConvert.DeserializeObject<List<MODELPhanQuyen>>(HttpContext.Session.GetString("fullRole"));
            }

            MODELPhanQuyen result = fullRole.FirstOrDefault(x => x.ControllerName == typeof(T).Name.ToLower());
            if (result == null) result = new MODELPhanQuyen();

            return result;
        }

        public string GetUserName()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    return User.Identity.Name;
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }
        public string GetUserPassword()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    var password = @User.Claims.FirstOrDefault(c => c.Type == "password");
                    if (password != null)
                    {
                        return password.Value;
                    }
                    else
                    {
                        throw new Exception("Vui lòng đăng nhập");
                    }
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }
        public string GetUserPasswordEncode()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    var password = @User.Claims.FirstOrDefault(c => c.Type == "passwordEncode");
                    if (password != null)
                    {
                        return password.Value;
                    }
                    else
                    {
                        throw new Exception("Vui lòng đăng nhập");
                    }
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }

        public string GetUserId()
        {
            try
            {
                if (User != null && User.Identity != null && User.Identity.Name != null)
                {
                    var UserId = @User.Claims.FirstOrDefault(c => c.Type == "userId");
                    if (UserId != null)
                    {
                        return UserId.Value;
                    }
                    else
                    {
                        throw new Exception("Vui lòng đăng nhập");
                    }
                }
                else
                {
                    throw new Exception("Vui lòng đăng nhập");
                }
            }
            catch
            {
                throw;
            }
        }

        #region Execute API
        public ResponseData GetAPI(string action)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    var responseTask = client.GetAsync(action);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PostAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
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
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PostFormDataAPI(string action, System.Net.Http.MultipartFormDataContent content)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsync(action, content);
                    responseTask.Wait();
                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData PutAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PutAsJsonAsync(action, model);
                    responseTask.Wait();

                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData DeleteAPI(string action)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.DeleteAsync(action);
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    response = ExecuteAPIResponse(responseTask);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData LoginAPI<T>(string action, T model)
        {
            ResponseData response = new ResponseData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetBEUrl());

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
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
                response.Message = MODELS.COMMON.CustomException.ConvertExceptionToMessage(ex, "Lỗi hệ thống.");
            }

            return response;
        }

        public ResponseData ExecuteAPIResponse(Task<HttpResponseMessage> responseTask)
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
            else
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống";
            }

            return response;

        }
        protected string GetCurrentUrl()
        {
            return Request.Scheme + "://" + Request.Host.Value;
        }

        private string GetBEUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
        }

        protected string GetBEFileUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
        }

        protected string GetDocviewerUrl()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DocviewerUrl").Value.ToString();
        }

        private string GetToken()
        {
            return HttpContext.User.Claims.Where(x => x.Type == "Token").FirstOrDefault().Value.ToString();
        }

        #endregion

        #region Các API dùng chung
        public PostTaiKhoanRequest GetQuyenTaiKhoan(Guid? taiKhoanId)
        {
            ResponseData response = new ResponseData();
            PostTaiKhoanRequest data = new PostTaiKhoanRequest();
            if (taiKhoanId != null)
            {
                response = this.PostAPI(URL_API.TAIKHOAN_GETBYPOST, new { Id = taiKhoanId });

                if (response.Status)
                {
                    data = JsonConvert.DeserializeObject<PostTaiKhoanRequest>(response.Data.ToString());
                }
            }
            return data;
        }
        #endregion
    }

    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = context.HttpContext.User.Claims.Where(x => x.Type == "Token").FirstOrDefault().Value.ToString();
                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEUrl").Value.ToString();
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseTask = client.PostAsJsonAsync(URL_API.PING, new { });
                    responseTask.Wait();
                    var result = responseTask.Result;

                    //CHECK 401
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}