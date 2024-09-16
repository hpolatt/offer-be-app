using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Rules;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler: BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;
    private readonly AuthRules authRules;
    public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.authRules = authRules;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = userManager.FindByNameAsync(request.Email).Result;
        await authRules.EmailAddressShouldBeExist(user);

        user.RefreshToken = null;
        userManager.UpdateAsync(user);
        
        return Unit.Value;
    }
}