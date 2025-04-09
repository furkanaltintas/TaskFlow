using Application.Common.Results.Abstract;
using Application.Common.Results.Concrete;
using Application.Features.Commands.AppTaskCommands;
using Application.Features.Constants.AppTaskConstants;
using Application.Interfaces.Requests;
using Application.Interfaces.UnitOfWorks;
using Application.Mappings;
using Domain.Entitites;

namespace Application.Features.Handlers.AppTaskHandlers;

public class CreateAppTaskCommandHandler(IUnitOfWork _uow) : IRequestHandler<CreateAppTaskCommandRequest, IDataResult<string>>
{
    public async Task<IDataResult<string>> Handle(CreateAppTaskCommandRequest request, CancellationToken cancellationToken)
    {
        await _uow
            .WriteRepository<AppTask>()
            .AddAsync(AppTaskMappings
            .ToCreateAppTaskResult(request));

        await _uow
            .SaveAsync(cancellationToken);

        return new SuccessDataResult<string>(AppTaskConstant.AppTaskCreated);
    }
}