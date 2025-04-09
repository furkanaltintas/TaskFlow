using Application.Common.Results.Concrete;
using Application.Features.Queries.AppTaskQueries;
using Application.Features.Results.AppTaskResults;
using Application.Interfaces.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class HomeController(IMediator mediator) : Controller
{
    public async Task<IActionResult> Index()
    {
        GetAllAppTaskQuery getAllAppTaskQuery = new();
        DataResult<List<GetAllAppTaskResult>> result = await mediator.SendAsync(getAllAppTaskQuery);
        return View(result.Data);
    }

    public async Task<IActionResult> Detail(int id)
    {
        GetAppTaskDetailQuery getAppTaskDetailQuery = new(id);
        DataResult<GetAppTaskDetailResult> result = await mediator.SendAsync(getAppTaskDetailQuery);
        return View(result.Data);
    }
}