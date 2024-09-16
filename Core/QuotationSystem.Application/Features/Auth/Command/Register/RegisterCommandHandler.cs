using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Rules;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly AuthRules authRule;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;

    public RegisterCommandHandler(AuthRules authRule, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.authRule = authRule;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await authRule.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));
        User user = mapper.Map<User, RegisterCommandRequest>(request);
        user.UserName = user.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();
        
        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            if (!await roleManager.RoleExistsAsync("user"))
            {
                await roleManager.CreateAsync(new Role 
                {
                    Id = Guid.NewGuid(),
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                 }
                 );
            }
            await userManager.AddToRoleAsync(user, "user");
        }
        return Unit.Value;
    }
}
