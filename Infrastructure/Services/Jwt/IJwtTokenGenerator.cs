using Domain.Entitites;
using Infrastructure.Configurations;

namespace Infrastructure.Services.Jwt;

public interface IJwtTokenGenerator
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}