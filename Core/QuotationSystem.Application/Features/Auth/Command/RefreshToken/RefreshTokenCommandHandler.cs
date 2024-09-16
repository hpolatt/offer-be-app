using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Rules;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.Interfaces.Tokens;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly ITokenService tokenService;
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;
    private readonly RoleManager<Role> roleManager;
    private readonly AuthRules authRules;

    public RefreshTokenCommandHandler(ITokenService tokenService, UserManager<User> userManager, IConfiguration configuration, RoleManager<Role> roleManager, AuthRules authRules, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.tokenService = tokenService;
        this.userManager = userManager;
        this.configuration = configuration;
        this.roleManager = roleManager;
        this.authRules = authRules;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);

        User user = await userManager.FindByNameAsync(email);
        IList<string> roles = await userManager.GetRolesAsync(user);

        await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

        JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
        string newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return new RefreshTokenCommandResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        };

    }

}