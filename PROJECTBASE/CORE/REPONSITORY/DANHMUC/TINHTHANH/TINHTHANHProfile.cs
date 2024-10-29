using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.TINHTHANH.Requests;
using MODELS.DANHMUC.TINHTHANH.Response;

namespace REPONSITORY.DANHMUC.DONVI
{
    public class TINHTHANHProfile : Profile
    {
        public TINHTHANHProfile()
        {
            CreateMap<SYS_TINHTHANH, MODELTinhThanh>();
            CreateMap<MODELTinhThanh, SYS_TINHTHANH>();
            CreateMap<PostTinhThanhRequest, SYS_TINHTHANH>();
            CreateMap<SYS_TINHTHANH, PostTinhThanhRequest>();
        }
    }
}
