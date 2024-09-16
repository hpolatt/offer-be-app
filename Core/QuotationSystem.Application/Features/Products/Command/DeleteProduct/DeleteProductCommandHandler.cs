using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Command.DeleteProduct;

public class DeleteProductCommandHandler: BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
{
    public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor) { }
    
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

        await unitOfWork.GetWriteRepository<Product>().DeleteAsync(product);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}