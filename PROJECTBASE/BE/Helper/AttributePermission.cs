using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using Newtonsoft.Json;
using REPONSITORY.HETHONG.TAIKHOAN;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.IdentityModel.Tokens.Jwt;

namespace BE.Helper
{
    public class AttributePermission : IActionFilter
    {
        ITAIKHOANService _tAIKHOANService;
        public AttributePermission(ITAIKHOANService tAIKHOANService)
        {
            _tAIKHOANService = tAIKHOANService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName.ToLower();
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName.ToLower();

            if(actionName.Contains("delete") || actionName.Contains("insert") || actionName.Contains("update"))
            {
                try
                {
                    //BO QUA MENU VA NHOM QUYEN DOI VOI TAI KHOAN ADMIN
                    if ((controllerName.Equals("menu") || controllerName.Equals("nhomquyen")) && context.HttpContext.User.Identity.Name == "admin") return;

                    //LAY DANH SACH PHAN QUYEN
                    List<MODELPhanQuyen> fullRole = new List<MODELPhanQuyen>();
                    if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("FULLPERMISION")))
                    {
                        var UserId = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name);
                        var taiKhoanResponse = _tAIKHOANService.GetPhanQuyen(new MODELS.HETHONG.TAIKHOAN.Requests.GetPhanQuyenRequest
                        {
                            UserId = Guid.Parse(UserId?.Value)
                        });
                        if (!taiKhoanResponse.Error)
                        {
                            context.HttpContext.Session.SetString("FULLPERMISION", Newtonsoft.Json.JsonConvert.SerializeObject(taiKhoanResponse.Data));
                            fullRole = taiKhoanResponse.Data;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        fullRole = JsonConvert.DeserializeObject<List<MODELPhanQuyen>>(context.HttpContext.Session.GetString("FULLPERMISION"));
                    }
                    //KIEM TRA PERMISSION
                    var phanQuyen = fullRole.FirstOrDefault(x => x.ControllerName.Equals(controllerName + "controller"));
                    if(phanQuyen != null)
                    {
                        if (actionName.Contains("insert") && !phanQuyen.IsThem) throw new Exception();
                        if (actionName.Contains("update") && !phanQuyen.IsCapNhat) throw new Exception();
                        if (actionName.Contains("delete") && !phanQuyen.IsXoa) throw new Exception();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    var _res = new { status = 401, Message = "Không có quyền truy cập", Data = "Không có quyền truy cập" };
                    context.Result = new JsonResult(_res);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
