using AutoDependencyRegistration.Attributes;
using AutoMapper;
using DATABASECONNECT.Infrastructure;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.DANHMUC.QUANHUYEN.Requests;
using MODELS.DANHMUC.QUANHUYEN.Response;

namespace REPONSITORY.DANHMUC.QUANHUYEN
{
    [RegisterClassAsTransient]
    public class QUANHUYENService : IQUANHUYENService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public QUANHUYENService(
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

                var result = _unitOfWork.GetRepository<MODELQuanHuyen>().ExcuteStoredProcedure("sp_DM_QuanHuyen_GetListPaging", parameters).ToList();
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
        public BaseResponse<PostQuanHuyenRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostQuanHuyenRequest>();
            try
            {
                var result = new PostQuanHuyenRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostQuanHuyenRequest>(data);
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
        public BaseResponse<MODELQuanHuyen> Insert(PostQuanHuyenRequest request)
        {
            var response = new BaseResponse<MODELQuanHuyen>();
            try
            {
                var data = _unitOfWork.GetRepository<SYS_QUANHUYEN>().Find(x => x.Ma == request.Ma && x.MaLienThong == request.MaLienThong && !x.IsDeleted);
                if (data != null)
                {
                    response.StatusCode = 500;
                    response.Message = "Dữ liệu đã tồn tại";
                    return response;
                }
                else
                {
                    var add = _mapper.Map<ENTITIES.DBContent.SYS_QUANHUYEN>(request);
                    add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                    add.NgayTao = DateTime.Now;
                    add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    add.NgaySua = DateTime.Now;
                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Add(add);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELQuanHuyen>(add);
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
        public BaseResponse<MODELQuanHuyen> Update(PostQuanHuyenRequest request)
        {
            var response = new BaseResponse<MODELQuanHuyen>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELQuanHuyen>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().Update(delete);
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
        public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllQuanHuyenRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_QUANHUYEN>().GetAll(x => (x.TinhThanhId == request.TinhThanhId || (request.IsMacDinh && x.TinhThanhId == CommonConst._tinhId)) && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
