using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.MENU.Requests
{
    public class PostMenuRequest : BaseRequest
    {
        public string? ControllerName { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; } = "index";
        public string? TenGoi { get; set; }
        public Guid? NhomQuyenId { get; set; }
        public bool CoXem { get; set; } = false;
        public bool CoThem { get; set; } = false;
        public bool CoCapNhat { get; set; } = false;
        public bool CoXoa { get; set; } = false;
        public bool CoDuyet { get; set; } = false;
        public bool CoThongKe { get; set; } = false;
        public bool IsShowMenu { get; set; } = true;
    }

    public class PostMenuRequestValidator : AbstractValidator<PostMenuRequest>
    {
        public PostMenuRequestValidator()
        {
            RuleFor(r => r.ControllerName).NotEmpty().WithMessage("ControllerName không được rỗng");
            RuleFor(r => r.Controller).NotEmpty().WithMessage("Controller không được rỗng");
            RuleFor(r => r.Action).NotEmpty().WithMessage("Action không được rỗng");
            RuleFor(r => r.TenGoi).NotEmpty().WithMessage("TenGoi không được rỗng");
            RuleFor(r => r.NhomQuyenId).NotNull().WithMessage("NhomQuyenId không được rỗng");
        }
    }
}
