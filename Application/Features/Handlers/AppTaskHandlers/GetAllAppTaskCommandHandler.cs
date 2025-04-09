using Application.Common.Results.Concrete;
using Application.Features.Queries.AppTaskQueries;
using Application.Features.Results.AppTaskResults;
using Application.Interfaces.Requests;
using Application.Interfaces.UnitOfWorks;
using Application.Mappings;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Handlers.AppTaskHandlers;

public class GetAllAppTaskCommandHandler(IUnitOfWork _uow) : IRequestHandler<GetAllAppTaskQuery, DataResult<List<GetAllAppTaskResult>>>
{
    public async Task<DataResult<List<GetAllAppTaskResult>>> Handle(GetAllAppTaskQuery request, CancellationToken cancellationToken)
    {
        List<AppTask> appTasks = await _uow
            .GetReadRepository<AppTask>()
            .GetAll()
            .Where(a => !a.IsDeleted)
            .Include(a => a.Priority) // Acil Durum
            .Include(a => a.RequestType) // Maintenance
            .Include(a => a.RelatedUnit) // Web
            .Include(a => a.TaskStatus) // Açık
            .Include(a => a.User) // Kullanıcı
            .OrderByDescending(a => a.Id)
            .ToListAsync();

        List<GetAllAppTaskResult> result = appTasks
            .Select(a => a.
            ToGetAllAppTaskResult())
            .ToList();

        return new SuccessDataResult<List<GetAllAppTaskResult>>(result);
    }
}