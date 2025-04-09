using Domain.Entitites;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.Jwt;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginCommandResponse> CreateToken(AppUser user)
    {
        DateTime expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpiryInDays);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: expires,
            claims: GetClaims(user),
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials);

        String token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        String refreshToken = Guid.NewGuid().ToString();
        DateTime refreshTokenExpires = expires.AddHours(1);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpires;

        await _userManager.UpdateAsync(user);
        return new(token, refreshToken, refreshTokenExpires);
    }


    private IEnumerable<Claim> GetClaims(AppUser user)
    {
        return new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName!),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName!),
            new Claim("id", user.Id.ToString()),
            new Claim("role", ""),
            new Claim("companyId", ""),
            new Claim("department", "" ?? ""),
            new Claim("phone", user.PhoneNumber ?? ""),
        };
    }
}