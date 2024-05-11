using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Persistence.Queries;

public class ScenarioSpaceQueries : IScenarioSpaceQueries
{
    public async Task<IList<ScenarioSpaceDto>> GetScenarioSpacesAsync(CancellationToken cancellationToken = default)
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