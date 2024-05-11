using MediatR;
using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace;

public class ScenarioSpaceListQuery : IRequest<IList<ScenarioSpaceDto>>
{
}

internal sealed class ScenarioSpaceListQueryHandler : IRequestHandler<ScenarioSpaceListQuery, IList<ScenarioSpaceDto>>
{
    private readonly IScenarioSpaceQueries _scenarioSpaceQueries;

    public ScenarioSpaceListQueryHandler(IScenarioSpaceQueries scenarioSpaceQueries)
    {
        _scenarioSpaceQueries = scenarioSpaceQueries;
    }

    public async Task<IList<ScenarioSpaceDto>> Handle(ScenarioSpaceListQuery request, CancellationToken cancellationToken)
    {
        return await _scenarioSpaceQueries.GetScenarioSpacesAsync();
    }
}