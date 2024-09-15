using System;
using MediatR;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = new(request.Name, request.Price, request.Description);
        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
