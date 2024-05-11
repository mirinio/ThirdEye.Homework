using ThirdEye.Homework.Application;

var builder = WebApplication.CreateBuilder(args);

var applicationAssembly = typeof(ApplicationAssembly).Assembly;

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors()
    .AddMediatR(c => c.RegisterServicesFromAssembly(applicationAssembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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