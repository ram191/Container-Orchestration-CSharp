using System;
using ProductService.Application.ProductMediator.Commands;
using FluentValidation;

namespace ProductService.Applications.ProductMediator.Commands
{
    public class ProductValidator : AbstractValidator<ProductCommand>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Data.Attributes.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Data.Attributes.Name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.Data.Attributes.Price).NotEmpty().WithMessage("price can't be empty ");
            RuleFor(x => x.Data.Attributes.Price).GreaterThan(1000).WithMessage("email is not valid email address");
        }
    }
}
