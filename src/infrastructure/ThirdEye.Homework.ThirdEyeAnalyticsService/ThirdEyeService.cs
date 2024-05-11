using System.Net.Http.Json;
using ThirdEye.Homework.Application.Services;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.ThirdEyeAnalyticsService;

public sealed class ThirdEyeService: IPortfolioAnalyticsService
{
    private readonly HttpClient _client;

    public ThirdEyeService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<ScenarioSpaceSummaryDto?> GetScenarioSpaceSummaryByNameAsync(string name)
    { 
        return await _client.GetFromJsonAsync<ScenarioSpaceSummaryDto>($"scenarioSpaceSummary?scenarioSpace={name}");
    }
}