using System;
using FluentValidation;

namespace MerchantService.Applications.MerchantMediator.Commands
{
    public class MerchantValidator : AbstractValidator<MerchantCommand>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.Data.Attributes.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Data.Attributes.Address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.Data.Attributes.Rating).InclusiveBetween(1, 5).WithMessage("rating is between 1-5");
        }
    }
}
