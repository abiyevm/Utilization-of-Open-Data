using DataTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Register ProblemService with HttpClient for dependency injection
builder.Services.AddHttpClient<ProblemService>();

// Add controllers and Swagger/OpenAPI support
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plant Monitoring API V1");
        c.RoutePrefix = string.Empty; // Swagger at root (http://localhost:<port>/)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map all controller endpoints
app.MapControllers();

app.Run();
