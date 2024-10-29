using FluentValidation;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class LoginRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().WithMessage("Tên đăng nhập không được rỗng");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Mật khẩu không được rỗng");
        }
    }
}
