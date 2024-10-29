using AutoMapper;
using ENTITIES.DBContent;
using MODELS.HETHONG.NHOMQUYEN.Requests;
using MODELS.HETHONG.VAITRO.Dtos;

namespace REPONSITORY.HETHONG.MENU
{
    public class NHOMQUYENProfile : Profile
    {
        public NHOMQUYENProfile()
        {
            CreateMap<PHANQUYEN_NHOMQUYEN, MODELNhomQuyen>();
            CreateMap<MODELNhomQuyen, PHANQUYEN_NHOMQUYEN>();
            CreateMap<PostNhomQuyenRequest, PHANQUYEN_NHOMQUYEN>();
            CreateMap<PHANQUYEN_NHOMQUYEN, PostNhomQuyenRequest>();
        }
    }
}
