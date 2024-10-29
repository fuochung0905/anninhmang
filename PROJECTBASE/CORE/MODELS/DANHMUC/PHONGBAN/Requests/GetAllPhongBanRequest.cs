using FluentValidation;
using MODELS.DANHMUC.PHONGBAN.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.PHUONGXA.Requests
{
    public class GetAllPhongBanRequest : GetAllRequest
    {
        public Guid? DonViId { get; set; }
    }

    public class GetAllPhongBanRequestValidator : AbstractValidator<GetAllPhongBanRequest>
    {
        public GetAllPhongBanRequestValidator()
        {
            RuleFor(r => r.DonViId).NotEmpty().WithMessage("Mã đơn vị không được rỗng");
        }
    }
}
