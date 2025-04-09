using Application.Common.Results.Abstract;
using Application.Interfaces.Requests;
using Microsoft.AspNetCore.Mvc;
namespace Application.Common.Responses;

[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
public class ApiController : ControllerBase
{
    protected readonly IMediator mediator;

    public ApiController(IMediator mediator) { this.mediator = mediator; }

    public async Task<IActionResult> Send<TResponse>(IRequest<IDataResult<TResponse>> request, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        IDataResult<TResponse> response = await mediator.SendAsync(request);
        return this.Response(response);
    }

    public async Task<IActionResult> Send<TResponse>(IRequest<IResult> request, CancellationToken cancellationToken = default)
    {
        IResult response = await mediator.SendAsync(request);
        return this.Response(response);
    }

    public async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        TResponse response = await mediator.SendAsync(request);
        return this.Response(response);
    }
}

internal static class ApiResponse
{
    public static IActionResult Response<T>(this ControllerBase controller, IDataResult<T> result)
    {
        if (result.IsSuccess) return controller.Ok(result);
        return controller.NotFound(result);
    }

    public static IActionResult Response(this ControllerBase controller, IResult result)
    {
        return result.IsSuccess
            ? controller.Ok(result)
            : controller.NotFound(result);
    }

    public static IActionResult Response<TResponse>(this ControllerBase controller, TResponse response)
        where TResponse : class
    {
        // İşlem başarılı ama veri yok ise 204 NoContent | null döneceğiz
        // İstek yanlışsa 400 BadRequest
        // Kayıt yoksa 404 NotFound

        return response is not null
            ? controller.Ok(response)
            : controller.NoContent();
    }
}