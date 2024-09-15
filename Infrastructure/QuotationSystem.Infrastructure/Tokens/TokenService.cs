using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuotationSystem.Application.Interfaces.Tokens;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly TokenSettings tokenSettings;
    private readonly UserManager<User> userManager;

    public TokenService(IOptions<TokenSettings> tokenSettings, UserManager<User> userManager)
    {
        this.tokenSettings = tokenSettings.Value;
        this.userManager = userManager;        
    }
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));
        var token = new JwtSecurityToken(
            issuer: tokenSettings.Issuer,
            audience: tokenSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidtyInMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        await userManager.AddClaimsAsync(user, claims);

        return token;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}
