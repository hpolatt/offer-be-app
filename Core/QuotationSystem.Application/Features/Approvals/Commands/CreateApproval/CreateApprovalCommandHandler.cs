using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Approvals.Commands.CreateApproval
{
    public class CreateApprovalCommandHandler : BaseHandler, IRequestHandler<CreateApprovalCommandRequest, Unit>
    {
        public CreateApprovalCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateApprovalCommandRequest request, CancellationToken cancellationToken)
        {
            Approval approval = new Approval(request.QuoteId, request.ApproverId, request.ApprovalStatus, request.Comments);
            await unitOfWork.GetWriteRepository<Approval>().AddAsync(approval);

            await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
