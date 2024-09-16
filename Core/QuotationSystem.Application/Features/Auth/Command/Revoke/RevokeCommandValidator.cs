using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Auth.Command.Revoke;

public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
{
    public RevokeCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
