using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
{
    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor) { }

    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

        var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

        await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
