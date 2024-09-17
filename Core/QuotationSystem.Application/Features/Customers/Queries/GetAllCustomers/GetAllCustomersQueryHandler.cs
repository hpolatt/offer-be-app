using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : BaseHandler, IRequestHandler<GetAllCustomersQueryRequest, IList<GetAllCustomersQueryResponse>>
{
    public GetAllCustomersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IList<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
    {
        IList<Customer> customers = await unitOfWork.GetReadRepository<Customer>().GetAllAsync();

        return mapper.Map<GetAllCustomersQueryResponse, Customer>(customers);
    }
}
