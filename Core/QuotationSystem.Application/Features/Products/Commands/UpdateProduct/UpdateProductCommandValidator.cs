using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.Name)
             .NotEmpty()
             .WithName("Name")
             .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Description")
            .MaximumLength(500);

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithName("Price")
            .GreaterThan(0);
    }

}
