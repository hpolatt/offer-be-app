using System;
using MediatR;

namespace QuotationSystem.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandRequest : IRequest<Unit>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

}
