using System;
using MediatR;

namespace QuotationSystem.Application.Features.Approvals.Commands.CreateApproval;

public class CreateApprovalCommandRequest: IRequest<Unit>
{
    public int QuoteId { get; set; }
    public  Guid ApproverId { get; set; }
    public  string ApprovalStatus { get; set; } = "pending"; // 'pending', 'approved', 'rejected'
    public DateTime? ApprovalDate { get; set; }
    public string? Comments { get; set; }
}
