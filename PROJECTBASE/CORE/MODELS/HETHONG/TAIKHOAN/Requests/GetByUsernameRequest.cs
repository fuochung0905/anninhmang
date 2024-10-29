using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetByUserNameRequest
    {
        public string? UserName { get; set; }
    }

    public class GetByUserNameRequestValidator : AbstractValidator<GetByUserNameRequest>
    {
        public GetByUserNameRequestValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().WithMessage("Tên đăng nhập không được rỗng");
        }
    }
}
