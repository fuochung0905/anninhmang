using BE.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.HETHONG.NHOMQUYEN.Requests;
using REPONSITORY.HETHONG.NHOMQUYEN;

namespace BE.Controllers.HETHONG
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomQuyenController : BaseController<NhomQuyenController>
    {
        INHOMQUYENService _service;

        public NhomQuyenController(INHOMQUYENService service)
        {
            _service = service;
        }

        [HttpPost, Route("get-list")]
        public IActionResult GetList(GetAllRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetList(request);
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
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetList"), ex);
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
        public IActionResult GetById(GetByIdRequest request)
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
        public IActionResult GetByPost(GetByIdRequest request)
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
        public IActionResult Insert(PostNhomQuyenRequest request)
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
        public IActionResult Update(PostNhomQuyenRequest request)
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

        [HttpPost, Route("get-all-combobox")]
        public IActionResult GetAllForCombobox(GetAllRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetAllForCombobox(request);
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
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetAllForCombobox"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }
    }
}
