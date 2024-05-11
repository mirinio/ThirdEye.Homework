using MediatR;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace;

public class ScenarioSpaceListQuery : IRequest<IList<ScenarioSpaceDto>>
{
}

internal sealed class ScenarioSpaceListQueryHandler : IRequestHandler<ScenarioSpaceListQuery, IList<ScenarioSpaceDto>>
{
    public async Task<IList<ScenarioSpaceDto>> Handle(ScenarioSpaceListQuery request, CancellationToken cancellationToken)
    {
        var list = new List<ScenarioSpaceDto>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Name1"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Name2"
            }
        };
        return await Task.FromResult(list);
    }
}