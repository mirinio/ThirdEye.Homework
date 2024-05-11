using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ThirdEye.Homework.Application;
using ThirdEye.Homework.Persistence;
using ThirdEye.Homework.ThirdEyeAnalyticsService;

var builder = WebApplication.CreateBuilder(args);

var applicationAssembly = typeof(ApplicationAssembly).Assembly;

builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddPersistence(builder.Configuration)
    .AddThirdEyeService(builder.Configuration)
    .AddCors()
    .AddMediatR(c => c.RegisterServicesFromAssembly(applicationAssembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<ThirdEyeHomeworkDbContext>().Database.Migrate();
    }
}


var origins = builder.Configuration.GetSection("CorsUrls").Get<string[]>();
app.UseCors(c =>
{
    if (origins != null) c.WithOrigins(origins);
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();