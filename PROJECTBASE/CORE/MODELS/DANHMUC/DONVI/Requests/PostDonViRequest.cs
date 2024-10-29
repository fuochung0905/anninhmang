using FluentValidation;

namespace MODELS.DANHMUC.Requests
{
    public class PostDonViRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string? TenGoi { get; set; }
        public string? NguoiLienHe { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? DiaChi { get; set; }
    }

    public class PostDonViRequestValidator : AbstractValidator<PostDonViRequest>
    {
        public PostDonViRequestValidator()
        {
            RuleFor(r => r.TenGoi).NotEmpty().WithMessage("Tên gọi không được rỗng");
        }
    }
}
