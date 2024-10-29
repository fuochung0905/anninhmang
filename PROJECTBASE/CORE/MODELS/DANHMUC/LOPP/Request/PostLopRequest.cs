using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.LOPP.Request
{
    public class PostLopRequest:BaseRequest
    {
        public Guid? Id { get; set; }

        public Guid? PhongBanId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên lớp không được để trống")]

        public string? Lop { get; set; } = null!;

    }
    public class PostLopRequestValidator : AbstractValidator<PostLopRequest>
    {
        public PostLopRequestValidator()
        {
            RuleFor(r => r.Lop).NotEmpty().WithMessage("Không được để trống");
        }
    }
}
