using AutoMapper;
using ENTITIES.DBContent;
using MODELS.HETHONG.VAITRO.Dtos;
using MODELS.HETHONG.VAITRO.Requests;

namespace REPONSITORY.HETHONG.MENU
{
    public class VAITROProfile : Profile
    {
        public VAITROProfile()
        {
            CreateMap<ENTITIES.DBContent.VAITRO, MODELVaiTro>();
            CreateMap<MODELVaiTro, ENTITIES.DBContent.VAITRO>();
            CreateMap<PostVaiTroRequest, ENTITIES.DBContent.VAITRO>();
            CreateMap<ENTITIES.DBContent.VAITRO, PostVaiTroRequest>();
            CreateMap<PHANQUYEN, MODELVaiTro_PhanQuyen>();
            CreateMap<PHANQUYEN_NHOMQUYEN, MODELNhomQuyen>();
            CreateMap<PostPhanQuyenVaiTroRequest, PHANQUYEN>();
        }
    }
}
