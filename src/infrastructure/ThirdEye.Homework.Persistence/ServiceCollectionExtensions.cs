using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Persistence.Queries;

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
        
        return services;
    }
    
}