using System;
using MediatR;
using QuotationSystem.Application.Interfaces.RedisCache;

namespace QuotationSystem.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryRequest : IRequest<IList<GetAllCustomersQueryResponse>>, ICacheableQuery
{
    public string CacheKey => "GetAllBrands";

    public double CacheTime => 5;
}
