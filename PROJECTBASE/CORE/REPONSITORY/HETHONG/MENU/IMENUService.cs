using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.MENU.Requests;
using MODELS.HETHONG.TAIKHOAN.Dtos;

namespace REPONSITORY.HETHONG.MENU
{
    public interface IMENUService
    {
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request);
        //BaseResponse<List<MODELMenu>> GetList(GetAllRequest request);
        BaseResponse<List<MODELMenu>> GetAll(GetAllRequest request);
        BaseResponse<MODELMenu> GetById(GetMenuByIdRequest request);
        BaseResponse<PostMenuRequest> GetByPost(GetMenuByIdRequest request);
        BaseResponse<MODELMenu> Insert(PostMenuRequest request);
        BaseResponse<MODELMenu> Update(PostMenuRequest request);
    }
}
