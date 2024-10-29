using FluentValidation;
using MODELS.DANHMUC.PHONGBAN.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.PHUONGXA.Requests
{
    public class GetAllPhuongXaRequest : GetAllRequest
    {
        public Guid? QuanHuyenId { get; set; }
    }

    public class GetAllPhuongXaRequestValidator : AbstractValidator<GetAllPhuongXaRequest>
    {
        public GetAllPhuongXaRequestValidator()
        {
            RuleFor(r => r.QuanHuyenId).NotEmpty().WithMessage("Mã quận huyện không được rỗng");
        }
    }
}
