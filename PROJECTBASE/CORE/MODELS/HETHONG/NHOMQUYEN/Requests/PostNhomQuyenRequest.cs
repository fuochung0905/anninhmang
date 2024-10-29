using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.NHOMQUYEN.Requests
{
    public class PostNhomQuyenRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string? TenGoi { get; set; }
        public string? Icon { get; set; }
    }

    public class PostNhomQuyenRequestValidator : AbstractValidator<PostNhomQuyenRequest>
    {
        public PostNhomQuyenRequestValidator()
        {
            RuleFor(r => r.TenGoi).NotEmpty().WithMessage("Tên gọi không được rỗng");
            RuleFor(r => r.Sort).NotNull().WithMessage("Thứ tự không được rỗng");
        }
    }
}
