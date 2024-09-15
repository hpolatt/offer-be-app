using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
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
