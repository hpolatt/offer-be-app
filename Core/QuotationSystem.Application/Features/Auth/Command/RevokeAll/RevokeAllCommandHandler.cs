using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;

    public RevokeAllCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
    }

    public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
    {
        IList<User> users = await userManager.Users.ToListAsync();

        foreach (User user in users)
        {
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}
