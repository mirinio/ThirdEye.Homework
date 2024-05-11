using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScenarioSpaceController: ControllerBase
{
    private readonly IMediator _mediator;

    public ScenarioSpaceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IList<ScenarioSpaceDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ScenarioSpaceList(CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new ScenarioSpaceListQuery(), cancellationToken);
        return Ok(result);
    }
}