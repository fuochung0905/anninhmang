using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.PHONGBAN.Dtos;
using MODELS.DANHMUC.PHONGBAN.Requests;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.HETHONG.TAIKHOAN.Requests;

namespace REPONSITORY.DANHMUC.PHONGBAN
{
    public interface IPHONGBANService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPhongBanRequest request);
        BaseResponse<MODELPhongBan> GetById(GetByIdRequest request);
        BaseResponse<PostPhongBanRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELPhongBan> Insert(PostPhongBanRequest request);
        BaseResponse<MODELPhongBan> Update(PostPhongBanRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForComboboxWithDonVi(GetAllPhongBanRequest request);
    }
}
