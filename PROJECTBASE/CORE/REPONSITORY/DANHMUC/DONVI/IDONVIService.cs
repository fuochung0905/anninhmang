using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;

namespace REPONSITORY.DANHMUC
{
    public interface IDONVIService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELDonVi> GetById(GetByIdRequest request);
        BaseResponse<PostDonViRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELDonVi> Insert(PostDonViRequest request);
        BaseResponse<MODELDonVi> Update(PostDonViRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
