using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;

namespace QuotationSystem.Application.Features.Customers.Commands.CreateCustomer;

public class CustomerCommandHandler : BaseHandler, IRequestHandler<CustomerCommandRequest, Unit>
{
    public CustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public Task<Unit> Handle(CustomerCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
