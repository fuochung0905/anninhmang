using Azure.Core;
using BE.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG.TAIKHOAN.Requests;
using REPONSITORY.HETHONG.LICENSE;
using REPONSITORY.HETHONG.MENU;

namespace BE.Controllers.HETHONG
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        ILICENSEService _service;

        public LicenseController(ILICENSEService service)
        {
            _service = service;
        }

        [HttpPost, Route("GetCodeRegister")]
        [AllowAnonymous]
        public IActionResult GetCodeRegister()
        {
            try
            {
                var result = _service.GetCodeRegister();
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }
    }
}
