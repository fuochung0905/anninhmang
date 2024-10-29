using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.CHUCVU.Dtos;
using MODELS.DANHMUC.CHUCVU.Requests;

namespace REPONSITORY.DANHMUC.CHUCVU
{
    public interface ICHUCVUService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELChucVu> GetById(GetByIdRequest request);
        BaseResponse<PostChucVuRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELChucVu> Insert(PostChucVuRequest request);
        BaseResponse<MODELChucVu> Update(PostChucVuRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
