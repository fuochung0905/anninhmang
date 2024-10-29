using FE.Constants;
using FE.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MODELS.BASE;

namespace FE.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("menu")))
            {
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETLISTMENU, new { UserId = GetUserId() });
                if (response.Status)
                {
                    HttpContext.Session.SetString("menu", response.Data.ToString());
                }
            }

            return View();
        }

        public IActionResult NoPermission()
        {
            return View("~/Views/Shared/NoPermission.cshtml");
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", exceptionFeature.Error.Message);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormCollection data)
        {
            try
            {
                var multiForm = new System.Net.Http.MultipartFormDataContent();

                // add API method parameters
                foreach (var file in data.Files)
                {
                    multiForm.Add(new StreamContent(file.OpenReadStream()), "files", file.FileName);
                }

                multiForm.Add(new StringContent(data["FolderName"]), "FolderName");

                ResponseData response = this.PostFormDataAPI(URL_API.UPLOADFILE, multiForm);

                if (!response.Status)
                {
                    return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                }

                return Json(new { IsSuccess = true, Message = "", Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi upload file: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public IActionResult Download(string filePath)
        {
            try
            {
                string beAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
                string fullPath = beAddress + filePath;
                using (var client = new HttpClient())
                {
                    using (var result = client.GetAsync(fullPath).Result)
                    {
                        var fileName = Path.GetFileName(fullPath);
                        var content = result.Content.ReadAsByteArrayAsync().Result;
                        var contentType = "application/octet-stream";

                        return File(content, contentType, fileName);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult ShowPopupDocumentReader(string documentUrl)
        {
            string beAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
            string fullPath = "https://docviewer.sjob.vn/Home/ShowFromHost?documentUrl=" + documentUrl + "&host=" + beAddress;
            ViewBag.Src = fullPath;
            return PartialView("~/Views/Home/PopupDocumnetReader.cshtml");
        }

        public IActionResult ShowPartialUploadFileInGrid(List<MODELTepDinhKem> obj)
        {
            return PartialView("~/Views/Shared/Components/UploadFileInGrid.cshtml", obj);
        }

        public ActionResult ShowPopupRecoder(MODELRecorder obj)
        {
            ViewBag.Domain = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();

            return PartialView("~/Views/Home/PopupRecorder.cshtml", obj);
        }

        public ActionResult ShowPopupScanQRCode()
        {
            return PartialView("~/Views/Home/PopupScanQRCode.cshtml");
        }
    }
}