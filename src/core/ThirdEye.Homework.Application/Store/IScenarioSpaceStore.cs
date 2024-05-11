using ThirdEye.Homework.Application.UseCases.Simulation.Models;

namespace ThirdEye.Homework.Application.Store;

public interface IScenarioSpaceStore
{
    Task UpdateRequestCountByNameAsync(string name, CancellationToken cancellationToken = default);
}