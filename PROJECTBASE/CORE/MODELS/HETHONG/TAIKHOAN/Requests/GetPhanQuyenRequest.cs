using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetPhanQuyenRequest
    {
        public Guid? UserId { get; set; }
    }

    public class GetPhanQuyenRequestValidator : AbstractValidator<GetPhanQuyenRequest>
    {
        public GetPhanQuyenRequestValidator()
        {
            RuleFor(r => r.UserId).NotNull().WithMessage("UserId không được rỗng");
        }
    }
}
