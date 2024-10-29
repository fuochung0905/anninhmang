using MODELS;
using MODELS.BASE;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;

namespace REPONSITORY.HETHONG.TAIKHOAN
{
    public interface ITAIKHOANService
    {
        BaseResponse<MODELTaiKhoanPhanQuyen> Login(LoginRequest request);
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingTaiKhoanRequest request);
        BaseResponse<MODELTaiKhoan> GetById(GetByIdRequest request);
        BaseResponse<PostTaiKhoanRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELTaiKhoan> GetByUserName(GetByUserNameRequest request);
        BaseResponse<MODELTaiKhoan> Insert(PostTaiKhoanRequest request);
        BaseResponse<MODELTaiKhoan> Update(PostTaiKhoanRequest request);
        BaseResponse<MODELTaiKhoan> ChangePassword(PostChangePasswordRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELMenu>> GetListMenu(GetListMenuRequest request);
        BaseResponse<List<MODELPhanQuyen>> GetPhanQuyen(GetPhanQuyenRequest request);
        BaseResponse<GetListPagingResponse> GetListNhatKy(GetListNhatKyRequest request);
        BaseResponse<GetListPagingResponse> GetListNhatKyTruyCap(GetListNhatKyRequest request);
        BaseResponse<GetListPagingResponse> GetListNhatKyThaoTac(GetListNhatKyRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
