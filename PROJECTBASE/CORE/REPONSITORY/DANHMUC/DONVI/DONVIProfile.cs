using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;

namespace REPONSITORY.DANHMUC.DONVI
{
    public class DONVIProfile : Profile
    {
        public DONVIProfile()
        {
            CreateMap<DM_DONVI, MODELDonVi>();
            CreateMap<MODELDonVi, DM_DONVI>();
            CreateMap<PostDonViRequest, DM_DONVI>();
            CreateMap<DM_DONVI, PostDonViRequest>();
        }
    }
}
