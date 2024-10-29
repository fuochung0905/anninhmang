using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetListMenuRequest
    {
        public Guid? UserId { get; set; }
    }

    public class GetListMenuRequestValidator : AbstractValidator<GetListMenuRequest>
    {
        public GetListMenuRequestValidator()
        {
            RuleFor(r => r.UserId).NotNull().WithMessage("UserId không được rỗng");
        }
    }
}
