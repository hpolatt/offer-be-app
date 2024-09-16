using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotEmpty();
    }

}
