using FluentValidation;
using MODELS.DANHMUC.PHONGBAN.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.PHUONGXA.Requests
{
    public class GetAllQuanHuyenRequest : GetAllRequest
    {
        public Guid? TinhThanhId { get; set; }
        //LẤY TỈNH MẶC ĐỊNH Ở HỆ THỐNG
        public bool IsMacDinh { get; set; } = true;
    }

    public class GetAllQuanHuyenRequestValidator : AbstractValidator<GetAllQuanHuyenRequest>
    {
        public GetAllQuanHuyenRequestValidator()
        {
            RuleFor(r => r.TinhThanhId).NotEmpty().WithMessage("Mã tỉnh thành không được rỗng");
        }
    }
}
