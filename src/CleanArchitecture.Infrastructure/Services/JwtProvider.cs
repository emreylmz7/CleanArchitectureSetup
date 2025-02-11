using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Options;
using ClenaArchitecture.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure.Services;

internal sealed class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    public Task<string> GenerateJwtToken(AppUser user, CancellationToken cancellationToken = default)
    {
        List<Claim> claims = new()
        {
            new Claim("user-id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName),
        };
        var expirationTime = DateTime.Now.AddMinutes(30);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expirationTime,
            signingCredentials: signingCredentials
        );
        JwtSecurityTokenHandler tokenHandler = new();

        string token = tokenHandler.WriteToken(securityToken);

        return Task.FromResult(token);
    }
}
