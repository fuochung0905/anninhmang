using AutoDependencyRegistration.Attributes;
using AutoMapper;
using DATABASECONNECT.Infrastructure;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.TINHTHANH.Requests;
using MODELS.DANHMUC.TINHTHANH.Response;

namespace REPONSITORY.DANHMUC.TINHTHANH
{
    [RegisterClassAsTransient]
    public class TINHTHANHService : ITINHTHANHService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public TINHTHANHService(
            IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        //GET LIST
        public BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingRequest request)
        {
            BaseResponse<GetListPagingResponse> response = new BaseResponse<GetListPagingResponse>();

            try
            {
                SqlParameter iTotalRow = new SqlParameter()
                {
                    ParameterName = "@oTotalRow",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output
                };


                var parameters = new[]
                {
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELTinhThanh>().ExcuteStoredProcedure("sp_DM_TinhThanh_GetListPaging", parameters).ToList();
                GetListPagingResponse resposeData = new GetListPagingResponse();
                resposeData.PageIndex = request.PageIndex;
                resposeData.Data = result;
                resposeData.TotalRow = Convert.ToInt32(iTotalRow.Value);
                response.Data = resposeData;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
        //GET BY POST (INSERT/UPDATE)
        public BaseResponse<PostTinhThanhRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostTinhThanhRequest>();
            try
            {
                var result = new PostTinhThanhRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostTinhThanhRequest>(data);
                    result.IsEdit = true;
                }
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //INSERT
        public BaseResponse<MODELTinhThanh> Insert(PostTinhThanhRequest request)
        {
            var response = new BaseResponse<MODELTinhThanh>();
            try
            {
                var data = _unitOfWork.GetRepository<SYS_TINHTHANH>().Find(x => x.Ma == request.Ma && x.MaLienThong == request.MaLienThong && !x.IsDeleted);
                if (data != null)
                {
                    response.StatusCode = 500;
                    response.Message = "Dữ liệu đã tồn tại";
                    return response;
                }
                else
                {
                    var add = _mapper.Map<ENTITIES.DBContent.SYS_TINHTHANH>(request);
                    add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                    add.NgayTao = DateTime.Now;
                    add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    add.NgaySua = DateTime.Now;
                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Add(add);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELTinhThanh>(add);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
                return response;
            }
        }

        //UPDATE
        public BaseResponse<MODELTinhThanh> Update(PostTinhThanhRequest request)
        {
            var response = new BaseResponse<MODELTinhThanh>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELTinhThanh>(update);
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //DELETE
        public BaseResponse<string> Delete(DeleteRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Update(delete);
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
                _unitOfWork.Commit();
                response.Data = request.Id.ToString();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //DELETE LIST
        public BaseResponse<string> DeleteList(DeleteListRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                foreach (var id in request.Ids)
                {
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().Update(delete);
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy dữ liệu");
                    }
                }
                _unitOfWork.Commit();
                response.Data = String.Join(',', request.Ids);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET ALL FOR COMBOBOX
        public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TINHTHANH>().GetAll(x => !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
