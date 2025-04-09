using Application.Common.Responses;
using Application.Features.Queries.AppTaskQueries;
using Application.Interfaces.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AppTasksController : ApiController
{
    public AppTasksController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        => await Send(new GetAllAppTaskQuery(), cancellationToken);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        => await Send(new GetAppTaskDetailQuery(id), cancellationToken);
}
