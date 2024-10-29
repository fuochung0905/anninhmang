using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.CHUCVU.Dtos;
using MODELS.DANHMUC.CHUCVU.Requests;

namespace REPONSITORY.DANHMUC.CHUCVU
{
    public class CHUCVUProfile : Profile
    {
        public CHUCVUProfile()
        {
            CreateMap<DM_CHUCVU, MODELChucVu>();
            CreateMap<MODELChucVu, DM_CHUCVU>();
            CreateMap<PostChucVuRequest, DM_CHUCVU>();
            CreateMap<DM_CHUCVU, PostChucVuRequest>();
        }
    }
}
