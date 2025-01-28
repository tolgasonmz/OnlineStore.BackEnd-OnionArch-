using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Title").WithMessage("Title is required");
            RuleFor(x => x.Price).NotEmpty().WithName("Price").WithMessage("Price is required");
            RuleFor(x => x.Price).GreaterThan(0).WithName("Price").WithMessage("Price must be greater than 0");
            RuleFor(x => x.BrandId).GreaterThan(0).NotEmpty().WithName("Brand").WithMessage("BrandId is required");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithName("Discount").WithMessage("Discount must be greater than or equal to 0");
        }
    }
}
