using MediatR;
using ThirdEye.Homework.Application.Services;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace;

public class ScenarioSpaceSummaryCommand : IRequest<ScenarioSpaceSummaryDto>
{
    public string Name { get; set; }
}

internal sealed class ScenarioSpaceSummaryCommandHandler : IRequestHandler<ScenarioSpaceSummaryCommand, ScenarioSpaceSummaryDto>
{
    private readonly IPortfolioAnalyticsService _analyticsService;

    public ScenarioSpaceSummaryCommandHandler(IPortfolioAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    public async Task<ScenarioSpaceSummaryDto> Handle(ScenarioSpaceSummaryCommand request, CancellationToken cancellationToken)
    {
        var result = await _analyticsService.GetScenarioSpaceSummaryByNameAsync(request.Name);
        return result;
    }
}