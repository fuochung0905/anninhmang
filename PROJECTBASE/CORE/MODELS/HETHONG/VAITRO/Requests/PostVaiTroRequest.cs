using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.VAITRO.Requests
{
    public class PostVaiTroRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string? TenGoi { get; set; }
    }

    public class PostVaiTroRequestValidator : AbstractValidator<PostVaiTroRequest>
    {
        public PostVaiTroRequestValidator()
        {
            RuleFor(r => r.TenGoi).NotEmpty().WithMessage("Tên gọi không được rỗng");
        }
    }
}
