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

    public PortfolioSimulationCommandHandler(IPortfolioAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }
    
    public async Task<AlphaSimulateDto?> Handle(PortfolioSimulationCommand request, CancellationToken cancellationToken)
    {
        return await _analyticsService.Simulate(request.Simulation, request.Name, cancellationToken);
    }
}