using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.CHUCVU.Requests
{
    public class PostChucVuRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã bắt buộc nhập")]
        public string? Ma { get; set; }
    }

    public class PostChucVuRequestValidator : AbstractValidator<PostChucVuRequest>
    {
        public PostChucVuRequestValidator()
        {
            RuleFor(r => r.TenGoi).NotEmpty().WithMessage("Tên gọi không được rỗng");
        }
    }
}
