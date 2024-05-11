using MediatR;
using ThirdEye.Homework.Application.Services;
using ThirdEye.Homework.Application.Store;
using ThirdEye.Homework.Application.UseCases.Simulation.Models;

namespace ThirdEye.Homework.Application.UseCases.Simulation;

public class PortfolioSimulationCommand : IRequest<AlphaSimulateDto?>
{
    public PortfoliosSimulationDto Simulation { get; set; }
    public string Name { get; set; }
}


internal sealed class PortfolioSimulationCommandHandler : IRequestHandler<PortfolioSimulationCommand, AlphaSimulateDto?>
{
    private readonly IPortfolioAnalyticsService _analyticsService;
    private readonly IScenarioSpaceStore _scenarioSpaceStore;
    public PortfolioSimulationCommandHandler(IPortfolioAnalyticsService analyticsService, IScenarioSpaceStore scenarioSpaceStore)
    {
        _analyticsService = analyticsService;
        _scenarioSpaceStore = scenarioSpaceStore;
    }
    
    public async Task<AlphaSimulateDto?> Handle(PortfolioSimulationCommand request, CancellationToken cancellationToken)
    {
        var result = await _analyticsService.Simulate(request.Simulation, request.Name, cancellationToken);
        await _scenarioSpaceStore.UpdateRequestCountByNameAsync(request.Name);
        return result;
    }
}