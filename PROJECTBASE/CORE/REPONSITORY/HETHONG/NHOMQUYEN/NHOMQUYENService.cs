﻿using AutoDependencyRegistration.Attributes;
using AutoMapper;
using DATABASECONNECT.Infrastructure;
using Microsoft.AspNetCore.Http;
using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.NHOMQUYEN.Requests;
using MODELS.HETHONG.VAITRO.Dtos;

namespace REPONSITORY.HETHONG.NHOMQUYEN
{
    [RegisterClassAsTransient]
    public class NHOMQUYENService : INHOMQUYENService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public NHOMQUYENService(
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
        public BaseResponse<List<MODELNhomQuyen>> GetList(GetAllRequest request)
        {
            var response = new BaseResponse<List<MODELNhomQuyen>>();
            try
            {
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().GetAll().OrderBy(x => x.Sort);
                response.Data = _mapper.Map<List<MODELNhomQuyen>>(data);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET BY ID
        public BaseResponse<MODELNhomQuyen> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELNhomQuyen>();
            try
            {
                var result = new MODELNhomQuyen();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELNhomQuyen>(data);
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
        public BaseResponse<PostNhomQuyenRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostNhomQuyenRequest>();
            try
            {
                var result = new PostNhomQuyenRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostNhomQuyenRequest>(data);
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
        public BaseResponse<MODELNhomQuyen> Insert(PostNhomQuyenRequest request)
        {
            var response = new BaseResponse<MODELNhomQuyen>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>(request);

                _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().Add(add);
                _unitOfWork.Commit();

                response.Data = _mapper.Map<MODELNhomQuyen>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELNhomQuyen> Update(PostNhomQuyenRequest request)
        {
            var response = new BaseResponse<MODELNhomQuyen>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().Update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELNhomQuyen>(update);
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

        //GET ALL
        public BaseResponse<List<MODELNhomQuyen>> GetAll(GetAllRequest request)
        {
            BaseResponse<List<MODELNhomQuyen>> response = new BaseResponse<List<MODELNhomQuyen>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().GetAll(x => x.IsActived).ToList();
            response.Data = _mapper.Map<List<MODELNhomQuyen>>(data).OrderBy(x => x.Sort).ToList();
            return response;
        }

        //GET ALL FOR COMBOBOX
        public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.PHANQUYEN_NHOMQUYEN>().GetAll(x => x.IsActived).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Text).ToList();

            return response;
        }
    }
}
