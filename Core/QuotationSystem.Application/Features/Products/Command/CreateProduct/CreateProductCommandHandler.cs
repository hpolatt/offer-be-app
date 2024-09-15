using System;
using MediatR;
using QuotationSystem.Application.Features.Products.Rules;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ProductRules productRules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
    {
        this.unitOfWork = unitOfWork;
        this.productRules = productRules;
    }
    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
        await productRules.ProductNameMustNotBeSame(products, request.Name);

        Product product = new(request.Name, request.Price, request.Description);
        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
