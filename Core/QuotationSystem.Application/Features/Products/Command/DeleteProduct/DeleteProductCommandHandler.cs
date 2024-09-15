using System;
using MediatR;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Command.DeleteProduct;

public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommandRequest, Unit>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

        await unitOfWork.GetWriteRepository<Product>().DeleteAsync(product);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}