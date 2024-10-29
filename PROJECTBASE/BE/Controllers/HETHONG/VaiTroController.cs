using BE.Helper;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.HETHONG.VAITRO.Requests;
using REPONSITORY.HETHONG.VAITRO;

namespace BE.Controllers.HETHONG
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTroController : BaseController<VaiTroController>
    {
        IVAITROService _service;

        public VaiTroController(IVAITROService service)
        {
            _service = service;
        }

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
        public IActionResult Insert(PostVaiTroRequest request)
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
        public IActionResult Update(PostVaiTroRequest request)
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

        [HttpPost, Route("delete-list")]
        public IActionResult DeleteList(DeleteListRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.DeleteList(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    //SysLog 
                    LogInfo(HttpContext.User.Identity.Name + " / DeleteList", new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(result.Data)));
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                //SysLog             
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi DeleteList"), ex);
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

        [HttpPost, Route("get-list-phan-quyen")]
        public IActionResult GetListPhanQuyenVaiTro(GetListPhanQuyenVaiTroRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetListPhanQuyenVaiTro(request);
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
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi GetListPhanQuyenVaiTro"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }

        [HttpPost, Route("post-phan-quyen")]
        public IActionResult PostPhanQuyenVaiTro(PostPhanQuyenVaiTroRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.PostPhanQuyenVaiTro(request);
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
                LogError(string.Format("{0} / {1}", HttpContext.User.Identity.Name, "Lỗi PostPhanQuyenVaiTro"), ex);
                return Ok(new ApiResponse(false, (int)MODELS.COMMON.StatusCode.InternalError, ex.Message));
            }
        }
    }
}
