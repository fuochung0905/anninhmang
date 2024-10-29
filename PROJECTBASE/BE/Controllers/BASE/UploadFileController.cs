using BE.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers.BASE
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : BaseController<UploadFileController>
    {
        IWebHostEnvironment _webHostEnvironment;

        public UploadFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Post(List<IFormFile> files, [FromForm] string FolderName)
        {
            try
            {
                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "Files/Temp/UploadFile/" + FolderName);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var stream = new FileStream(folderPath + "/" + file.FileName, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }

                return Ok(new ApiOkResponse(result: null, success: true, statusCode: (int)MODELS.COMMON.StatusCode.Success, message: ""));
            }

            catch (ArgumentException ex)
            {
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi UPLOAD FILE"), ex);
                return BadRequest(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }
    }
}
