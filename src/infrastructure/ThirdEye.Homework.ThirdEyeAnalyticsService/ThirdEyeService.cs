using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ThirdEye.Homework.Application.Services;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;
using ThirdEye.Homework.Application.UseCases.Simulation.Models;

namespace ThirdEye.Homework.ThirdEyeAnalyticsService;

public sealed class ThirdEyeService: IPortfolioAnalyticsService
{
    private readonly HttpClient _client;

    public ThirdEyeService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<ScenarioSpaceSummaryDto?> GetScenarioSpaceSummaryByNameAsync(string name, CancellationToken cancellationToken = default)
    { 
        return await _client.GetFromJsonAsync<ScenarioSpaceSummaryDto>($"scenarioSpaceSummary?scenarioSpace={name}",cancellationToken);
    }

    public async Task<AlphaSimulateDto?> Simulate(PortfoliosSimulationDto simulation, string name, CancellationToken cancellationToken = default)
    {
        var portfolioSimulation = new StringContent(
            JsonSerializer.Serialize(simulation),
            Encoding.UTF8,
            System.Net.Mime.MediaTypeNames.Application.Json);

        using var httpResposneMessage = await _client.PostAsync($"simulations?scenarioSpace={name}", portfolioSimulation, cancellationToken);

        var test = await httpResposneMessage.Content.ReadFromJsonAsync<AlphaSimulateDto>(cancellationToken: cancellationToken);

        return test;
    }
}