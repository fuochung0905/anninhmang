using BE.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.HETHONG.MENU.Requests;
using REPONSITORY.HETHONG.MENU;

namespace BE.Controllers.HETHONG
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController<MenuController>
    {
        IMENUService _service;

        public MenuController(IMENUService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lấy danh sách dữ liệu (có phân trang)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("get-list-paging")]
        public IActionResult GetListPaging(GetListPagingRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetListPaging(request);
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
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetListPaging"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("get-all")]
        public IActionResult GetAll(GetAllRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetAll(request);
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
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetAll"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("get-by-id")]
        public IActionResult GetById(GetMenuByIdRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetById(request);
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
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetById"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("get-by-post")]
        public IActionResult GetByPost(GetMenuByIdRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetByPost(request);
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
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetByPost"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("insert")]
        public IActionResult Insert(PostMenuRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.Insert(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    //SysLog 
                    LogInfo(HttpContext.User.Identity.Name + " / Insert", new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(result.Data)));
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi Insert"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("update")]
        public IActionResult Update(PostMenuRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.Update(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    //SysLog 
                    LogInfo(HttpContext.User.Identity.Name + " / Update", new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(result.Data)));
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi Update"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }
    }
}
