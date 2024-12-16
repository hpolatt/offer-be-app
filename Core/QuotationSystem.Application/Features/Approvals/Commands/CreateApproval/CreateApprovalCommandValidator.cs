using System;
using FluentValidation;

namespace QuotationSystem.Application.Features.Approvals.Commands.CreateApproval;

public class CreateApprovalCommandValidator: AbstractValidator<CreateApprovalCommandRequest>
{
    public CreateApprovalCommandValidator()
    {
        RuleFor(x => x.QuoteId)
            .NotEmpty()
            .WithName("QuoteId");

        RuleFor(x => x.ApproverId)
            .NotEmpty()
            .WithName("ApproverId");

        RuleFor(x => x.ApprovalStatus)
            .NotEmpty()
            .WithName("ApprovalStatus")
            .MaximumLength(50);

        RuleFor(x => x.Comments)
            .MaximumLength(500)
            .WithName("Comments");
    }

}
