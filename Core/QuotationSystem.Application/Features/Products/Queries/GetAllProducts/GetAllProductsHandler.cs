using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuotationSystem.Application.DTOs;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;
namespace QuotationSystem.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IList<GetAllProductsResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(p => p.QuoteItems));
            var mappedQuotes = mapper.Map<QuoteItemDto, List<QuoteItem>>(products.SelectMany(x => x.QuoteItems).ToList());
            // mapper.Map<QuoteItemDto, List<QuoteItem>>(products.SelectMany(x => x.QuoteItems).ToList());
            
            var map = mapper.Map<GetAllProductsResponse, Product>(products);
            foreach (var item in map)
                item.NetPrice = item.Price * 1.15;
            
            return map;
            
        }
    }
}

