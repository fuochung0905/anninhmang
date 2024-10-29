using FluentValidation;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class PostChangePasswordRequest
    {
        public Guid? Id { get; set; }
        public string? MatKhauCu { get; set; } = string.Empty;
        public string? MatKhauMoi { get; set; } = string.Empty;
        public string? XacNhanMatKhauMoi { get; set; } = string.Empty;
    }

    public class PostChangePasswordRequestValidator : AbstractValidator<PostChangePasswordRequest>
    {
        public PostChangePasswordRequestValidator()
        {
            RuleFor(r => r.Id).NotNull().WithMessage("Id không được rỗng");
            RuleFor(r => r.MatKhauCu).NotEmpty().WithMessage("Mật khẩu cũ không được rỗng");
            RuleFor(r => r.MatKhauMoi).NotEmpty().WithMessage("Mật khẩu mới không được rỗng");
        }
    }
}
