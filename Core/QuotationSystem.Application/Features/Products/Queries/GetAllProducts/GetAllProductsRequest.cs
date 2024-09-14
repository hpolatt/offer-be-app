using System;
using MediatR;

namespace QuotationSystem.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<IList<GetAllProductsResponse>>
    {
      
    }
}

