namespace Infrastructure.Configurations;

public record LoginCommandResponse(string Token, string RefreshToken, DateTime RefreshTokenExpires);