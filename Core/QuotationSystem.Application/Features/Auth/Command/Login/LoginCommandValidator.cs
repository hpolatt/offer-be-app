using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Auth.Command.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{

    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }

}
