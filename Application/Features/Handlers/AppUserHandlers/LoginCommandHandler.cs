using Application.Common.Results.Concrete;
using Application.Features.Commands.AppUserCommands;
using Application.Features.Constants.AppUserConstants;
using Application.Interfaces.Requests;
using Domain.Entitites;
using Infrastructure.Configurations;
using Infrastructure.Services.Jwt;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.AppUserHandlers;

public class LoginCommandHandler(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginCommandRequest, DataResult<LoginCommandResponse>>
{
    public async Task<DataResult<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null) return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserNotFound);

        var checkResult = await CheckUser(user, request);
        if (!checkResult.IsSuccess) return checkResult;

        return await GenerateToken(user);
    }

    private async Task<DataResult<LoginCommandResponse>> CheckUser(AppUser user, LoginCommandRequest request)
    {
        SignInResult result = await signInManager.PasswordSignInAsync(user, request.Password, request.IsRememberMe, true);

        if (!result.Succeeded) return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserNameOrPasswordWrong);
        if (result.IsNotAllowed) return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserNotApproved);
        if (result.IsLockedOut)
        {
            if (user.LockoutEnd.HasValue)
            {
                TimeSpan? timeSpan = user.LockoutEnd?.Subtract(DateTime.UtcNow);

                if (timeSpan is not null) return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserIsLockedOutTimeSpan(timeSpan.Value.TotalMinutes));
                else return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserIsLockedOutNull);
            }
            else
                return new ErrorDataResult<LoginCommandResponse>(AppUserConstant.UserIsLockedOutNull);
        }

        return new SuccessDataResult<LoginCommandResponse>();
    }

    private async Task<DataResult<LoginCommandResponse>> GenerateToken(AppUser user)
    {
        LoginCommandResponse loginCommandResponse = await jwtTokenGenerator.CreateToken(user);
        return new SuccessDataResult<LoginCommandResponse>(loginCommandResponse, AppUserConstant.LoginSuccessful(user.FirstName));
    }
}