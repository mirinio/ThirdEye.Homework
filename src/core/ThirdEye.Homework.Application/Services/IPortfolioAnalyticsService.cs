using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.Services;

public interface IPortfolioAnalyticsService
{
    Task<ScenarioSpaceSummaryDto?> GetScenarioSpaceSummaryByNameAsync(string name);
}