using AutoDependencyRegistration.Attributes;
using AutoMapper;
using DATABASECONNECT.Infrastructure;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.TAIKHOAN.Requests;
using REPONSITORY.HETHONG.NHOMQUYEN;

namespace REPONSITORY.HETHONG.TAIKHOAN
{
    [RegisterClassAsTransient]
    public class TAIKHOANService : ITAIKHOANService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _config;
        private INHOMQUYENService _nhomQuyenService;
        private IWebHostEnvironment _webHostEnvironment;

        public TAIKHOANService(
            IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IConfiguration config,
            INHOMQUYENService nhomQuyenService,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _config = config;
            _nhomQuyenService = nhomQuyenService;
            _webHostEnvironment = webHostEnvironment;
        }

        //LOGIN
        public BaseResponse<MODELTaiKhoanPhanQuyen> Login(LoginRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoanPhanQuyen>();
            try
            {
                var data = new MODELTaiKhoanPhanQuyen();
                var taiKhoan = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.UserName.ToLower() == request.UserName.ToLower());
                if (taiKhoan == null)
                {
                    throw new Exception("Tài khoản hoặc mật khẩu không đúng");
                }
                else
                {
                    var pass = Encrypt_Decrypt.EncodePassword(request.Password, taiKhoan.MatKhauSalt);
                    if (!pass.Equals(taiKhoan.MatKhau))
                    {
                        throw new Exception("Tài khoản hoặc mật khẩu không đúng");
                    }

                    var token = Encrypt_Decrypt.GenerateJwtToken(new MODELTaiKhoan { Id = Guid.Parse(taiKhoan.Id.ToString()), UserName = request.UserName }, _config);
                    data.TaiKhoan = _mapper.Map<MODELTaiKhoan>(taiKhoan);
                    data.TaiKhoan.Guid = pass;
                    data.TaiKhoan.AnhDaiDien = string.IsNullOrWhiteSpace(taiKhoan.AnhDaiDien) ? "Files/no-image.png" : taiKhoan.AnhDaiDien;
                    data.TaiKhoan.Token = token;
                    data.Menu = GetListMenu(new GetListMenuRequest { UserId = taiKhoan.Id }).Data
                        .Select(x => new MODELMenuLogin
                        {
                            Action = x.Action,
                            Controller = x.Controller,
                            NhomQuyenId = x.NhomQuyenId,
                            TenGoi = x.TenGoi,
                            Sort = x.Sort,
                            IsShowMenu = x.IsShowMenu
                        }).ToList();
                    data.PhanQuyen = GetPhanQuyen(new GetPhanQuyenRequest { UserId = taiKhoan.Id }).Data;
                    data.NhomQuyen = _nhomQuyenService.GetList(new GetAllRequest()).Data.Where(x => x.IsActived == true)
                        .Select(x => new MODELNhomQuyenLogin
                        {
                            Id = x.Id,
                            Sort = x.Sort,
                            TenGoi = x.TenGoi,
                            Icon = x.Icon,
                        }).ToList();

                    response.Data = data;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET LIST PAGING
        public BaseResponse<GetListPagingResponse> GetListPaging(GetListPagingTaiKhoanRequest request)
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
                    new SqlParameter("@iPhongBanId", request.PhongBanId.HasValue ? request.PhongBanId : DBNull.Value),
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELTaiKhoan>().ExcuteStoredProcedure("sp_TaiKhoan_GetListPaging", parameters).ToList();
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

        //GET BY ID (FIND)
        public BaseResponse<MODELTaiKhoan> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoan>();
            try
            {
                var result = new MODELTaiKhoan();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == request.Id && x.IsDeleted == false);
                if (data == null)
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
                else
                {
                    result = _mapper.Map<MODELTaiKhoan>(data);
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

        //GET BY POST (INSERT/UPDATE)
        public BaseResponse<PostTaiKhoanRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostTaiKhoanRequest>();
            try
            {
                var result = new PostTaiKhoanRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == request.Id && x.IsDeleted == false);
                if (data == null)
                {
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostTaiKhoanRequest>(data);
                    result.MatKhau = "@h1h1 Đồ Ngốc";
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

        //GET BY USERNAME
        public BaseResponse<MODELTaiKhoan> GetByUserName(GetByUserNameRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoan>();
            try
            {
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.UserName == request.UserName);
                if (data == null)
                    throw new Exception(MODELS.COMMON.CommonMessage.KHONGTIMTHAYDULIEU);
                else
                {
                    var dataMap = _mapper.Map<MODELTaiKhoan>(data);
                    dataMap.AnhDaiDien = string.IsNullOrWhiteSpace(data.AnhDaiDien) ? "~/images/no-image.png" : data.AnhDaiDien;
                    response.Data = dataMap;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //INSERT
        public BaseResponse<MODELTaiKhoan> Insert(PostTaiKhoanRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoan>();
            try
            {
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().GetAll(x => (x.UserName == request.UserName)
                    && x.IsDeleted == false).FirstOrDefault();
                if (data != null)
                {
                    throw new Exception("Tài khoản đã tồn tại");
                }

                var add = _mapper.Map<ENTITIES.DBContent.TAIKHOAN>(request);
                var salt = Encrypt_Decrypt.GenerateSalt();
                add.MatKhauSalt = salt;
                add.MatKhau = Encrypt_Decrypt.EncodePassword(request.MatKhau, salt);
                add.Id = Guid.NewGuid();
                add.AnhDaiDien = UploadAvata(request.FolderUpload, "");
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name == null ? "admin" : _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name == null ? "admin" : _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Add(add);
                _unitOfWork.Commit();

                response.Data = _mapper.Map<MODELTaiKhoan>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELTaiKhoan> Update(PostTaiKhoanRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoan>();
            try
            {
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().GetAll(x => x.Id != request.Id && (x.UserName == request.UserName)
                    && x.IsDeleted == false).FirstOrDefault();

                if (data != null)
                {
                    throw new Exception("Tài khoản đã tồn tại");
                }

                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    // Nếu đổi mật khẩu thì cập nhật lại mật khẩu mới
                    if (request.MatKhau != "@h1h1 Đồ Ngốc")
                    {
                        update.MatKhau = Encrypt_Decrypt.EncodePassword(request.MatKhau, update.MatKhauSalt);
                    }

                    update.AnhDaiDien = UploadAvata(request.FolderUpload, update.AnhDaiDien);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELTaiKhoan>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Update(delete);
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

        //CHANGE PASSWORD
        public BaseResponse<MODELTaiKhoan> ChangePassword(PostChangePasswordRequest request)
        {
            var response = new BaseResponse<MODELTaiKhoan>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == request.Id && x.IsDeleted == false);
                if (update != null)
                {
                    if (!request.MatKhauMoi.Equals(request.XacNhanMatKhauMoi)) throw new Exception("Xác nhận mật khẩu mới không đúng");

                    // Nếu đổi mật khẩu thì cập nhật lại mật khẩu mới
                    var pass = Encrypt_Decrypt.EncodePassword(request.MatKhauCu, update.MatKhauSalt);
                    if (!pass.Equals(update.MatKhau)) throw new Exception("Mật khẩu cũ không đúng");

                    var salt = Encrypt_Decrypt.GenerateSalt();
                    update.MatKhauSalt = salt;
                    update.MatKhau = Encrypt_Decrypt.EncodePassword(request.MatKhauMoi, salt);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELTaiKhoan>(update);
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

        //GET PHÂN QUYỀN
        public BaseResponse<List<MODELPhanQuyen>> GetPhanQuyen(GetPhanQuyenRequest request)
        {
            var response = new BaseResponse<List<MODELPhanQuyen>>();
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@UserId", request.UserId),
                };

                response.Data = _unitOfWork.GetRepository<MODELPhanQuyen>().ExcuteStoredProcedure("sp_TaiKhoan_LayDanhSachPhanQuyenTheoUser", parameters).ToList();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET MENU
        public BaseResponse<List<MODELMenu>> GetListMenu(GetListMenuRequest request)
        {
            var response = new BaseResponse<List<MODELMenu>>();
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@UserId", request.UserId),
                };

                response.Data = _unitOfWork.GetRepository<MODELMenu>().ExcuteStoredProcedure("sp_TaiKhoan_LayDanhSachMenu", parameters).ToList();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET LIST NHẬT KÝ
        public BaseResponse<GetListPagingResponse> GetListNhatKy(GetListNhatKyRequest request)
        {
            var response = new BaseResponse<GetListPagingResponse>();
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
                    new SqlParameter("@TuNgay", request.TuNgay),
                    new SqlParameter("@DenNgay", request.DenNgay),
                    new SqlParameter("@Level", request.Level),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELNhatKy>().ExcuteStoredProcedure("sp_Log_GetList", parameters).ToList();
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

        //GET LIST NHẬT KÝ TRUY CẬP
        public BaseResponse<GetListPagingResponse> GetListNhatKyTruyCap(GetListNhatKyRequest request)
        {
            var response = new BaseResponse<GetListPagingResponse>();
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
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@TuNgay", request.TuNgay),
                    new SqlParameter("@DenNgay", request.DenNgay),
                    new SqlParameter("@iDonViId", string.IsNullOrEmpty(request.DonViId) ? Guid.Empty : request.DonViId),
                    new SqlParameter("@Level", request.Level),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELNhatKy>().ExcuteStoredProcedure("sp_NhatKyTruyCap_GetListPaging", parameters).ToList();
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

        //GET LIST NHẬT KÝ THAO TÁC
        public BaseResponse<GetListPagingResponse> GetListNhatKyThaoTac(GetListNhatKyRequest request)
        {
            var response = new BaseResponse<GetListPagingResponse>();
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
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@TuNgay", request.TuNgay),
                    new SqlParameter("@DenNgay", request.DenNgay),
                    new SqlParameter("@iDonViId", string.IsNullOrEmpty(request.DonViId) ? Guid.Empty : request.DonViId),
                    new SqlParameter("@Level", request.Level),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELNhatKy>().ExcuteStoredProcedure("sp_NhatKyThaoTac_GetListPaging", parameters).ToList();
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

        private string UploadAvata(string folderUpload, string oldImage)
        {
            string path = oldImage;
            string folderUploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\Temp\\UploadFile\\" + folderUpload);
            if (Directory.Exists(folderUploadPath))
            {
                string[] arrFiles = Directory.GetFiles(folderUploadPath);
                if (arrFiles.Count() > 0) //có đính kèm
                {
                    FileInfo info = new FileInfo(arrFiles[0]);
                    string fileName = Guid.NewGuid().ToString() + info.Extension;
                    string avataPath = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\ANHDAIDIEN");
                    //Kiểm tra nếu thư mục chưa tồn tại thì tạo mới.
                    if (!Directory.Exists(avataPath))
                    {
                        Directory.CreateDirectory(avataPath);
                    }

                    //Xóa ảnh cũ nếu tồn tại
                    if (File.Exists(avataPath + "\\" + oldImage))
                    {
                        File.Delete(avataPath + "\\" + oldImage);
                    }

                    //Copy ảnh mới
                    File.Move(arrFiles[0], avataPath + "\\" + fileName, true);
                    path = "Files\\ANHDAIDIEN\\" + fileName;
                }
            }

            return path;
        }

        //GET ALL FOR COMBOBOX
        public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.UserName,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
