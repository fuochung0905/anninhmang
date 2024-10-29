using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.TINHTHANH.Requests;
using MODELS.DANHMUC.TINHTHANH.Response;

namespace REPONSITORY.DANHMUC.TINHTHANH
{
    public interface ITINHTHANHService
    {
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request);
        BaseResponse<PostTinhThanhRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELTinhThanh> Insert(PostTinhThanhRequest request);
        BaseResponse<MODELTinhThanh> Update(PostTinhThanhRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
