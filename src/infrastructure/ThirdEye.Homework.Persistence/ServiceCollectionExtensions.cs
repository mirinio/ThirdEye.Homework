using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Application.Store;
using ThirdEye.Homework.Persistence.Queries;
using ThirdEye.Homework.Persistence.Store;

namespace ThirdEye.Homework.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnection = configuration["ConnectionString"];
        
        services.AddDbContext<ThirdEyeHomeworkDbContext>(o =>
        {
            o.UseSqlServer(dbConnection);
        });
        
        services.AddScoped<IScenarioSpaceQueries, ScenarioSpaceQueries>();
        services.AddScoped<IScenarioSpaceStore, ScenarioSpaceStore>();
        
        return services;
    }
    
}