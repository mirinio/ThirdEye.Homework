using Microsoft.Extensions.DependencyInjection;
using ThirdEye.Homework.Application.Queries;
using ThirdEye.Homework.Persistence.Queries;

namespace ThirdEye.Homework.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IScenarioSpaceQueries, ScenarioSpaceQueries>();
        return services;
    }
    
}