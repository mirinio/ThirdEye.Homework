using Microsoft.EntityFrameworkCore;
using ThirdEye.Homework.Application.Store;

namespace ThirdEye.Homework.Persistence.Store;

public class ScenarioSpaceStore: IScenarioSpaceStore
{
    private readonly ThirdEyeHomeworkDbContext _context;

    public ScenarioSpaceStore(ThirdEyeHomeworkDbContext context)
    {
        _context = context;
    }

    public async Task UpdateRequestCountByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var space = await _context.ScenarioSpaces.Where(s => s.Name == name).FirstOrDefaultAsync(cancellationToken);
        if(space is not null) space.RequestCount++;
        await _context.SaveChangesAsync(cancellationToken);
    }
}