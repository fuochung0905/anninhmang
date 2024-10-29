using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.VAITRO.Dtos;
using Newtonsoft.Json;

namespace PROJECTBASE.Views.Shared.Components.LeftMenu
{
    public class LeftMenuViewComponent : ViewComponent
    {
        public LeftMenuViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            List<MODELMenuLogin> menu = new List<MODELMenuLogin>();
            List<MODELNhomQuyenLogin> nhomQuyen = new List<MODELNhomQuyenLogin>();
            Guid userId = Guid.Empty;
            foreach (var claim in HttpContext.User.Claims)
            {
                if (claim.Type == "userId")
                {
                    userId = Guid.Parse(claim.Value);
                }
                if (claim.Type == "nhomQuyen")
                {
                    nhomQuyen = JsonConvert.DeserializeObject<List<MODELNhomQuyenLogin>>(claim.Value);
                }

            }


            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("menu")))
            {
                menu = JsonConvert.DeserializeObject<List<MODELMenuLogin>>(HttpContext.Session.GetString("menu"));
            }

            ViewBag.MENUHEADER = nhomQuyen.OrderBy(x => x.Sort).ToList();
            ViewBag.MENUITEM = menu.Where(x => x.IsShowMenu).ToList();
            return View();
        }
    }
}
