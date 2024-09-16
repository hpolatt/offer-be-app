using System;
using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QuotationSystem.Application.Base;
using QuotationSystem.Application.Features.Auth.Exceptions;
using QuotationSystem.Application.Features.Auth.Rules;
using QuotationSystem.Application.Interfaces.AutoMapper;
using QuotationSystem.Application.Interfaces.Tokens;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;
    private readonly ITokenService tokenService;
    private readonly RoleManager<Role> roleManager;
    private readonly AuthRules authRules;

    public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration, ITokenService tokenService, RoleManager<Role> roleManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.configuration = configuration;
        this.tokenService = tokenService;
        this.roleManager = roleManager;
        this.authRules = authRules;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByNameAsync(request.Email);
        bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
        await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

        IList<string> roles = await userManager.GetRolesAsync(user);

        JwtSecurityToken token = await tokenService.CreateToken(user, roles);
        user.RefreshToken = tokenService.GenerateRefreshToken();

        _ = int.TryParse(configuration["JWT:RefreshTokenExpirationInDays"], out int refreshTokenExpirationInDays);

        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenExpirationInDays);

        var x = await userManager.UpdateAsync(user);
        await userManager.UpdateSecurityStampAsync(user);


        string _token = new JwtSecurityTokenHandler().WriteToken(token);
        await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

        return new()
        {
            Token = _token,
            RefreshToken = user.RefreshToken,
            Expiration = token.ValidTo
        };
    }

}

