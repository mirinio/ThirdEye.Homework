using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;
using ThirdEye.Homework.Application.UseCases.Simulation.Models;

namespace ThirdEye.Homework.Application.Services;

public interface IPortfolioAnalyticsService
{
    Task<ScenarioSpaceSummaryDto?> GetScenarioSpaceSummaryByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<AlphaSimulateDto?> Simulate(PortfoliosSimulationDto simulation, string name, CancellationToken cancellationToken = default);
}