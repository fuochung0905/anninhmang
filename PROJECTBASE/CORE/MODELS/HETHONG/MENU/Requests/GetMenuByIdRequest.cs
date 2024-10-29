using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.MENU.Requests
{
    public class GetMenuByIdRequest : BaseRequest
    {
        public string ControllerName { get; set; }
    }

    public class GetMenuByIdRequestValidator : AbstractValidator<GetMenuByIdRequest>
    {
        public GetMenuByIdRequestValidator()
        {
            RuleFor(r => r.ControllerName).NotEmpty().WithMessage("ControllerName không được rỗng");
        }
    }
}
