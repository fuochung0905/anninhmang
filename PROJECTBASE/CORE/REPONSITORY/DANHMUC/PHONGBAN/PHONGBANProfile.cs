using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.PHONGBAN.Dtos;
using MODELS.DANHMUC.PHONGBAN.Requests;

namespace REPONSITORY.DANHMUC.DONVI
{
    public class PHONGBANProfile : Profile
    {
        public PHONGBANProfile()
        {
            CreateMap<DM_PHONGBAN, MODELPhongBan>();
            CreateMap<MODELPhongBan, DM_PHONGBAN>();
            CreateMap<PostPhongBanRequest, DM_PHONGBAN>();
            CreateMap<DM_PHONGBAN, PostPhongBanRequest>();
        }
    }
}
