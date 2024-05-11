var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors();


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