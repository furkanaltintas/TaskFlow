using Application.Common.Results.Abstract;
using Application.Interfaces.Requests;

namespace Application.Features.Commands.AppTaskCommands;

public record CreateAppTaskCommandRequest(
    string Title,
    string Description,
    int PriorityId,
    int AppUserId) : IRequest<IDataResult<string>>;