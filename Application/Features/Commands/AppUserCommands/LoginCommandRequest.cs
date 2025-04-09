using Application.Common.Results.Concrete;
using Application.Interfaces.Requests;
using Infrastructure.Configurations;

namespace Application.Features.Commands.AppUserCommands;

public record LoginCommandRequest(string Email, string Password, bool IsRememberMe) : IRequest<DataResult<LoginCommandResponse>>;