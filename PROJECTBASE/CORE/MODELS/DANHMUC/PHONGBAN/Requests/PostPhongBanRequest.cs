using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.PHONGBAN.Requests
{
   public class PostPhongBanRequest : BaseRequest
   {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
        public Guid DonViId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã bắt buộc nhập")]
        public string? Ma { get; set; }
        public string? TenDonVi { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }
        public bool IsKhoa { get; set; }
    }
   public class PostPhongBanRequestValidator : AbstractValidator<PostPhongBanRequest>
   {
      public PostPhongBanRequestValidator()
      {
         RuleFor(r => r.Ma).NotEmpty().WithMessage("Mã không được rỗng");
         RuleFor(r => r.TenGoi).NotEmpty().WithMessage("Tên gọi không được rỗng");
      }
   }
}
