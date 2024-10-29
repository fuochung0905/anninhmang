using FluentValidation;
using MODELS;
using System.ComponentModel.DataAnnotations;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class PostTaiKhoanRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = null!;
        public Guid? TinhId { get; set; }
        public Guid? HuyenId { get; set; }
        public Guid? XaId { get; set; }
        public Guid? VaiTroId { get; set; }
        public Guid? DonViId { get; set; }
        public Guid? PhongBanId { get; set; }
        //Nhập số điện thoại cần 10 số
        [RegularExpression("^[Z0-9]{10}$", ErrorMessage = "Nhập 10 chữ (số)")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string SoDienThoai { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? HoLot { get; set; } = null!;
        public string? Ten { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        /// <summary>
        /// 0: nam, 1: nữ
        /// </summary>
        public int? GioiTinh { get; set; } = 0;
        public string? AnhDaiDien { get; set; }
        public string? MatKhau { get; set; } = null!;
    }

    public class PostTaiKhoanRequestValidator : AbstractValidator<PostTaiKhoanRequest>
    {
        public PostTaiKhoanRequestValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().WithMessage("UserName không được rỗng");
            RuleFor(r => r.VaiTroId).NotNull().WithMessage("Vai trò không được rỗng");
            RuleFor(r => r.Email).NotNull().WithMessage("Email không được rỗng");
            RuleFor(r => r.SoDienThoai).NotNull().WithMessage("Số điện thoại không được rỗng");
            RuleFor(r => r.DonViId).NotNull().WithMessage("Đơn vị không được rỗng");
            RuleFor(r => r.PhongBanId).NotNull().WithMessage("Phòng ban không được rỗng");
            RuleFor(r => r.Ten).NotEmpty().WithMessage("Tên không được rỗng");
            RuleFor(r => r.HoLot).NotEmpty().WithMessage("Họ không được rỗng");
            RuleFor(r => r.NgaySinh).NotNull().WithMessage("Ngày sinh không được rỗng");
        }
    }
}