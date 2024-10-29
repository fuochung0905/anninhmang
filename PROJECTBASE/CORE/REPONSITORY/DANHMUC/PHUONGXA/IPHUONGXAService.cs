using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.DANHMUC.PHUONGXA.Response;

namespace REPONSITORY.DANHMUC.PHUONGXA
{
    public interface IPHUONGXAService
    {
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request);
        BaseResponse<PostPhuongXaRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELPhuongXa> Insert(PostPhuongXaRequest request);
        BaseResponse<MODELPhuongXa> Update(PostPhuongXaRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllPhuongXaRequest request);
    }
}
