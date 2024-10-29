using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.QUANHUYEN.Requests;
using MODELS.DANHMUC.QUANHUYEN.Response;

namespace REPONSITORY.DANHMUC.DONVI
{
    public class QUANHUYENProfile : Profile
    {
        public QUANHUYENProfile()
        {
            CreateMap<SYS_QUANHUYEN, MODELQuanHuyen>();
            CreateMap<MODELQuanHuyen, SYS_QUANHUYEN>();
            CreateMap<PostQuanHuyenRequest, SYS_QUANHUYEN>();
            CreateMap<SYS_QUANHUYEN, PostQuanHuyenRequest>();
        }
    }
}
