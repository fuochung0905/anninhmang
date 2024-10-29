using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.DANHMUC.QUANHUYEN.Requests;
using MODELS.DANHMUC.QUANHUYEN.Response;

namespace REPONSITORY.DANHMUC.QUANHUYEN
{
    public interface IQUANHUYENService
    {
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request);
        BaseResponse<PostQuanHuyenRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELQuanHuyen> Insert(PostQuanHuyenRequest request);
        BaseResponse<MODELQuanHuyen> Update(PostQuanHuyenRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllQuanHuyenRequest request);
    }
}
