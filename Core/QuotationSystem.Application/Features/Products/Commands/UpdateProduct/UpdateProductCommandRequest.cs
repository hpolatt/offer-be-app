using System;
using MediatR;

namespace QuotationSystem.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
