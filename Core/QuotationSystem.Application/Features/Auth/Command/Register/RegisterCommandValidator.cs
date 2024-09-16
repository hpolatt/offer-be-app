using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.FullName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress()
            .MinimumLength(5)
            .WithMessage("{PropertyName} is not a valid email address.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(8)
            .WithMessage("{PropertyName} must not be less than 6 characters.");
        
        RuleFor(p => p.ConfirmPassword)
            .Equal(p => p.Password)
            .WithMessage("Passwords do not match.");
    }
}
