using Crud.Database;
using Crud.Entities;
using Crud.Requests;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CrudContext>();

CrudContext context = new();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

#region Carrier
app.MapGet("/carriers", () =>
{
    var carriers = context.Carriers.Select(x => x);
    return carriers.Any() ? Results.Ok(carriers) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Carrier)} entity from the database.");

app.MapGet("/carriers/{id}", (Guid id) =>
{
    var carrier = context.Carriers.FirstOrDefault(x => x.Id.Equals(id));
    return carrier is not null ? Results.Ok(carrier) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Carrier)} entity from the database with the specified id.");

app.MapPost("/carriers", async ([FromBody] CarrierRequest request ) =>
{
    Carrier carrier = new() { Name = request.Name };

    await context.Carriers.AddAsync(carrier);
    await context.SaveChangesAsync();

    return Results.Ok(carrier);
}).WithSummary($"Adds a {nameof(Carrier)} into the database.");

app.MapPut("/carriers/{id}", async (Guid id, [FromBody] CarrierRequest request) =>
{
    var carrier = context.Carriers.FirstOrDefault(x => x.Id.Equals(id));
    if (carrier is null) return Results.NotFound();

    carrier.Name = request.Name;
    await context.SaveChangesAsync();

    return Results.NoContent();
}).WithSummary($"Adds a {nameof(Carrier)} into the database.");
#endregion

#region Customer
#endregion

#region Driver
#endregion

#region Product
#endregion

#region ProductKind
#endregion

#region Recipient
#endregion

#region Route
#endregion

#region Vehicle
#endregion

app.Run();