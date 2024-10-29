using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG;
using System.Security.Claims;

namespace PROJECTBASE.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        IHttpContextAccessor _contextAccessor;

        public HeaderViewComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            MODELTaiKhoan model = new MODELTaiKhoan();
            var HostBE = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();

            foreach (var claim in _contextAccessor.HttpContext.User.Claims)
            {
                switch (claim.Type)
                {
                    case ClaimTypes.Name: { model.UserName = claim.Value; }; break;
                    case ClaimTypes.Surname: { model.HoLot = claim.Value; }; break;
                    case ClaimTypes.GivenName: { model.Ten = claim.Value; }; break;
                    case ClaimTypes.Thumbprint: { model.AnhDaiDien = HostBE + claim.Value; }; break;
                }
            }
            ViewBag.UserInfo = model;
            return View();
        }
    }
}
