using AutoMapper;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Requests;

namespace REPONSITORY.HETHONG.MENU
{
    public class TAIKHOANProfile : Profile
    {
        public TAIKHOANProfile()
        {
            CreateMap<ENTITIES.DBContent.TAIKHOAN, MODELTaiKhoan>();
            CreateMap<MODELTaiKhoan, ENTITIES.DBContent.TAIKHOAN>();
            CreateMap<PostTaiKhoanRequest, ENTITIES.DBContent.TAIKHOAN>().ForMember(x => x.MatKhau, opt => opt.Ignore());
            CreateMap<ENTITIES.DBContent.TAIKHOAN, PostTaiKhoanRequest>();
        }
    }
}
