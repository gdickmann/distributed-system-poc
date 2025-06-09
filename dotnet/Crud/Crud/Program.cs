using Crud.Database;
using Crud.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CrudContext>();

CrudContext context = new();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

context.Carriers.Add(new());
await context.SaveChangesAsync();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/carriers", () => context.Carriers.Select(x => x))
    .WithSummary($"Retrieves the {nameof(Carrier)} entity from the database.");

app.Run();