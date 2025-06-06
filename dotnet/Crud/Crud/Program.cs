var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health-check", () => "Healthy!")
    .WithName("Health check")
    .WithSummary("Does a health check on the back-end.")
    .WithDescription("This endpoint returns a friendly greeting string to the caller.");

app.Run();