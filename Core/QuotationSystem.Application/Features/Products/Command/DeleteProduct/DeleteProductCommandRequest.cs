using System;
using MediatR;

namespace QuotationSystem.Application.Features.Products.Command.DeleteProduct;

public class DeleteProductCommandRequest: IRequest
{
    public int Id { get; set; }
}
