using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Application.Queries;

public interface IScenarioSpaceQueries
{
    Task<IList<ScenarioSpaceDto>> GetScenarioSpacesAsync(CancellationToken cancellationToken = default);
}