using Application.Common.Results.Concrete;
using Application.Features.Queries.AppTaskQueries;
using Application.Features.Results.AppTaskResults;
using Application.Interfaces.Requests;
using Application.Interfaces.UnitOfWorks;
using Application.Mappings;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Handlers.AppTaskHandlers;

class GetAppTaskDetailCommandHandler(IUnitOfWork _uow) : IRequestHandler<GetAppTaskDetailQuery, DataResult<GetAppTaskDetailResult>>
{
    public async Task<DataResult<GetAppTaskDetailResult>> Handle(GetAppTaskDetailQuery request, CancellationToken cancellationToken)
    {
        List<AppTask> appTasks = await _uow
            .GetReadRepository<AppTask>()
            .GetAll()
            .Include(a => a.User)
            .Include(a => a.TaskStatus)
            .Include(a => a.RelatedUnit)
            .Include(a => a.RequestType).ToListAsync(cancellationToken);

        GetAppTaskDetailResult? appTask = appTasks
            .Where(a => a.Id == request.Id)
            .Select(a => a
            .ToGetAppTaskDetailResult())
            .FirstOrDefault();

        if (appTask is null) throw new Exception("AppTask not found");

        return new DataResult<GetAppTaskDetailResult>(appTask, true);
    }
}