using System;
using MediatR;
using QuotationSystem.Application.DTOs;

namespace QuotationSystem.Application.Features.Products.Queries.GetAllProducts
{
  public class GetAllProductsResponse
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double NetPrice { get; set; }
    public QuoteItemDto QuoteItems { get; set; }
  }
}

