using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThirdEye.Homework.Application.UseCases.Simulation;
using ThirdEye.Homework.Application.UseCases.Simulation.Models;

namespace ThirdEye.Homework.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimulationController: ControllerBase
{
    private readonly IMediator _mediator;

    public SimulationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(AlphaSimulateDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SimulatePortfolio(string name, [FromBody]PortfoliosSimulationDto portfoliosSimulationDto, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new PortfolioSimulationCommand(){Simulation = portfoliosSimulationDto, Name = name}, cancellationToken);
        return Ok(result);
    }
}