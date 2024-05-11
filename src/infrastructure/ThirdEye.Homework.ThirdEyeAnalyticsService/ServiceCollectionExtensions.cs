using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThirdEye.Homework.Application.Services;

namespace ThirdEye.Homework.ThirdEyeAnalyticsService;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddThirdEyeService(this IServiceCollection services, IConfiguration configuration)
    {
        var apiKey = configuration["ThirdEyesApiKey"];
        services.AddHttpClient<IPortfolioAnalyticsService, ThirdEyeService>(s =>
        {
            s.BaseAddress = new Uri("https://stage.3rd-eyes.com/api/public/v1/");
            s.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            s.DefaultRequestHeaders.Add("X-API-Key", apiKey);
        });
        return services;
    }
}