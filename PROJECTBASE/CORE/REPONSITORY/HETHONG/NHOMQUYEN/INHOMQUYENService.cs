using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.NHOMQUYEN.Requests;
using MODELS.HETHONG.VAITRO.Dtos;

namespace REPONSITORY.HETHONG.NHOMQUYEN
{
    public interface INHOMQUYENService
    {
        BaseResponse<List<MODELNhomQuyen>> GetList(GetAllRequest request);
        BaseResponse<MODELNhomQuyen> GetById(GetByIdRequest request);
        BaseResponse<PostNhomQuyenRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELNhomQuyen> Insert(PostNhomQuyenRequest request);
        BaseResponse<MODELNhomQuyen> Update(PostNhomQuyenRequest request);
        BaseResponse<List<MODELNhomQuyen>> GetAll(GetAllRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
