using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.DANHMUC.PHUONGXA.Response;

namespace REPONSITORY.DANHMUC.DONVI
{
    public class PHUONGXAProfile : Profile
    {
        public PHUONGXAProfile()
        {
            CreateMap<SYS_PHUONGXA, MODELPhuongXa>();
            CreateMap<MODELPhuongXa, SYS_PHUONGXA>();
            CreateMap<PostPhuongXaRequest, SYS_PHUONGXA>();
            CreateMap<SYS_PHUONGXA, PostPhuongXaRequest>();
        }
    }
}
