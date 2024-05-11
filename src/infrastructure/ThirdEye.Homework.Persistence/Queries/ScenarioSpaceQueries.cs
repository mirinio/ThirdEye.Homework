using Microsoft.EntityFrameworkCore;
using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

namespace ThirdEye.Homework.Persistence.Queries;

public class ScenarioSpaceQueries : IScenarioSpaceQueries
{
    private readonly ThirdEyeHomeworkDbContext _context;

    public ScenarioSpaceQueries(ThirdEyeHomeworkDbContext context)
    {
        _context = context;
    }

    public async Task<IList<ScenarioSpaceDto>> GetScenarioSpacesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ScenarioSpaces.Select(s => new ScenarioSpaceDto()
        {
            Id = s.Id,
            Name = s.Name,
            AssetClassCashType = s.AssetClassCashType,
        }).ToListAsync(cancellationToken);
    }
}