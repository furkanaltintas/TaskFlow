using Application.Common.Results.Concrete;
using Application.Features.Results.AppTaskResults;
using Application.Interfaces.Requests;

namespace Application.Features.Queries.AppTaskQueries;

public record GetAllAppTaskQuery() : IRequest<DataResult<List<GetAllAppTaskResult>>>;