using AutoMapper;
using ENTITIES.DBContent;
using MODELS.HETHONG.MENU.Requests;
using MODELS.HETHONG.TAIKHOAN.Dtos;

namespace REPONSITORY.HETHONG.MENU
{
    public class MENUProfile : Profile
    {
        public MENUProfile()
        {
            CreateMap<SYS_MENU, MODELMenu>();
            CreateMap<MODELMenu, SYS_MENU>();
            CreateMap<PostMenuRequest, SYS_MENU>();
            CreateMap<SYS_MENU, PostMenuRequest>();
        }
    }
}
