using MediatR;
using ThirdEye.Homework.Application.Services;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace;

public class ScenarioSpaceSummaryQuery : IRequest<ScenarioSpaceSummaryDto?>
{
    public string Name { get; set; }
}

internal sealed class ScenarioSpaceSummaryQueryHandler : IRequestHandler<ScenarioSpaceSummaryQuery, ScenarioSpaceSummaryDto?>
{
    private readonly IPortfolioAnalyticsService _analyticsService;

    public ScenarioSpaceSummaryQueryHandler(IPortfolioAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    public async Task<ScenarioSpaceSummaryDto?> Handle(ScenarioSpaceSummaryQuery request, CancellationToken cancellationToken)
    {
        var result = await _analyticsService.GetScenarioSpaceSummaryByNameAsync(request.Name, cancellationToken);
        return result;
    }
}