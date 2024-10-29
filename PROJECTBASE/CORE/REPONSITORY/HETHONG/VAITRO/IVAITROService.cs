using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.VAITRO.Dtos;
using MODELS.HETHONG.VAITRO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPONSITORY.HETHONG.VAITRO
{
    public interface IVAITROService
    {
        BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request);
        BaseResponse<MODELVaiTro> GetById(GetByIdRequest request);
        BaseResponse<PostVaiTroRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELVaiTro> Insert(PostVaiTroRequest request);
        BaseResponse<MODELVaiTro> Update(PostVaiTroRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
        BaseResponse<List<MODELVaiTro_PhanQuyen>> GetListPhanQuyenVaiTro(GetListPhanQuyenVaiTroRequest request);
        BaseResponse<MODELVaiTro_PhanQuyen> PostPhanQuyenVaiTro(PostPhanQuyenVaiTroRequest request);
    }
}
