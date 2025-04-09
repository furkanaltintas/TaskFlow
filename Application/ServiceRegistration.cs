using Application.Common.Results.Concrete;
using Application.Features.Handlers.AppTaskHandlers;
using Application.Features.Queries.AppTaskQueries;
using Application.Features.Results.AppTaskResults;
using Application.Interfaces.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();

        services.AddScoped<IRequestHandler<GetAllAppTaskQuery, DataResult<List<GetAllAppTaskResult>>>, GetAllAppTaskCommandHandler>();
        services.AddScoped<IRequestHandler<GetAppTaskDetailQuery, DataResult<GetAppTaskDetailResult>>, GetAppTaskDetailCommandHandler>();
    }
}