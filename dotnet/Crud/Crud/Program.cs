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
app.MapGet("/customers", () =>
{
    var customers = context.Customers.Select(x => x);
    return customers.Any() ? Results.Ok(customers) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Customer)} entity from the database.");

app.MapGet("/customers/{id}", (Guid id) =>
{
    var customer = context.Customers.FirstOrDefault(x => x.Id.Equals(id));
    return customer is not null ? Results.Ok(customer) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Customer)} entity from the database with the specified id.");

app.MapPost("/customers", async ([FromBody] CustomerRequest request) =>
{
    Customer customer = new() { Name = request.Name };

    await context.Customers.AddAsync(customer);
    await context.SaveChangesAsync();

    return Results.Ok(customer);
}).WithSummary($"Adds a {nameof(Customer)} into the database.");

app.MapPut("/customers/{id}", async (Guid id, [FromBody] CustomerRequest request) =>
{
    var customer = context.Customers.FirstOrDefault(x => x.Id.Equals(id));
    if (customer is null) return Results.NotFound();

    customer.Name = request.Name;
    await context.SaveChangesAsync();

    return Results.NoContent();
}).WithSummary($"Updates a {nameof(Customer)} into the database.");
#endregion

#region Driver
app.MapGet("/drivers", () =>
{
    var drivers = context.Drivers.Select(x => x);
    return drivers.Any() ? Results.Ok(drivers) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Driver)} entity from the database.");

app.MapGet("/drivers/{id}", (Guid id) =>
{
    var driver = context.Drivers.FirstOrDefault(x => x.Id.Equals(id));
    return driver is not null ? Results.Ok(driver) : Results.NotFound();

}).WithSummary($"Retrieves the {nameof(Driver)} entity from the database with the specified id.");

app.MapPost("/drivers", async ([FromBody] DriverRequest request) =>
{
    Carrier? carrier = context.Carriers.FirstOrDefault(x => x.Id.Equals(request.CarrierId));
    if (carrier is null) return Results.BadRequest($"Entidade {nameof(Carrier)} de id {request.CarrierId} não foi encontrada na base de dados.");

    Vehicle? vehicle = context.Vehicles.FirstOrDefault(x => x.Id.Equals(request.VehicleId));
    if (vehicle is null) return Results.BadRequest($"Entidade {nameof(Vehicle)} de id {request.VehicleId} não foi encontrada na base de dados.");

    Driver driver = new() { Name = request.Name, CarrierId = request.CarrierId, VehicleId = request.VehicleId };

    await context.Drivers.AddAsync(driver);
    await context.SaveChangesAsync();

    return Results.Ok(driver);
}).WithSummary($"Adds a {nameof(Driver)} into the database.");

app.MapPut("/drivers/{id}", async (Guid id, [FromBody] DriverRequest request) =>
{
    var driver = context.Drivers.FirstOrDefault(x => x.Id.Equals(id));
    if (driver is null) return Results.NotFound();

    Carrier? carrier = context.Carriers.FirstOrDefault(x => x.Id.Equals(request.CarrierId));
    if (carrier is null) return Results.BadRequest($"Entidade {nameof(Carrier)} de id {request.CarrierId} não foi encontrada na base de dados.");

    Vehicle? vehicle = context.Vehicles.FirstOrDefault(x => x.Id.Equals(request.VehicleId));
    if (vehicle is null) return Results.BadRequest($"Entidade {nameof(Vehicle)} de id {request.VehicleId} não foi encontrada na base de dados.");

    driver.Name = request.Name;
    driver.CarrierId = request.CarrierId;
    driver.VehicleId = request.VehicleId;

    await context.SaveChangesAsync();

    return Results.NoContent();
}).WithSummary($"Updates a {nameof(Driver)} into the database.");
#endregion

#region Product
app.MapGet("/products", () =>
{
    var products = context.Products.Select(x => x);
    return products.Any() ? Results.Ok(products) : Results.NotFound();
}).WithSummary($"Retrieves the {nameof(Product)} entity from the database.");

app.MapGet("/products/{id}", (Guid id) =>
{
    var product = context.Products.FirstOrDefault(x => x.Id.Equals(id));
    return product is not null ? Results.Ok(product) : Results.NotFound();
}).WithSummary($"Retrieves the {nameof(Product)} entity from the database with the specified id.");

app.MapPost("/products", async ([FromBody] ProductRequest request) =>
{
    ProductKind? productKind = context.ProductKinds.FirstOrDefault(x => x.Id.Equals(request.ProductKindId));
    if (productKind is null) return Results.BadRequest($"Entidade {nameof(ProductKind)} de id {request.ProductKindId} não foi encontrada na base de dados.");

    Product product = new() { Name = request.Name, ProductKindId = request.ProductKindId };

    await context.Products.AddAsync(product);
    await context.SaveChangesAsync();

    return Results.Ok(product);
}).WithSummary($"Adds a {nameof(Product)} into the database.");

app.MapPut("/products/{id}", async (Guid id, [FromBody] ProductRequest request) =>
{
    var product = context.Products.FirstOrDefault(x => x.Id.Equals(id));
    if (product is null) return Results.NotFound();

    ProductKind? productKind = context.ProductKinds.FirstOrDefault(x => x.Id.Equals(request.ProductKindId));
    if (productKind is null) return Results.BadRequest($"Entidade {nameof(ProductKind)} de id {request.ProductKindId} não foi encontrada na base de dados.");

    product.Name = request.Name;
    product.ProductKindId = request.ProductKindId;

    await context.SaveChangesAsync();

    return Results.NoContent();
}).WithSummary($"Updates a {nameof(Driver)} into the database.");
#endregion

#region ProductKind
app.MapGet("/product-kinds", () =>
{
    var productKinds = context.ProductKinds.Select(x => x);
    return productKinds.Any() ? Results.Ok(productKinds) : Results.NotFound();
}).WithSummary($"Retrieves the {nameof(ProductKind)} entity from the database.");

app.MapGet("/product-kinds/{id}", (Guid id) =>
{
    var productKind = context.ProductKinds.FirstOrDefault(x => x.Id.Equals(id));
    return productKind is not null ? Results.Ok(productKind) : Results.NotFound();
}).WithSummary($"Retrieves the {nameof(ProductKind)} entity from the database with the specified id.");

app.MapPost("/product-kinds", async ([FromBody] ProductKindRequest request) =>
{
    ProductKind productKind = new() { Name = request.Name };

    await context.ProductKinds.AddAsync(productKind);
    await context.SaveChangesAsync();

    return Results.Ok(productKind);
}).WithSummary($"Adds a {nameof(ProductKind)} into the database.");

app.MapPut("/product-kinds/{id}", async (Guid id, [FromBody] ProductKindRequest request) =>
{
    ProductKind? productKind = context.ProductKinds.FirstOrDefault(x => x.Id.Equals(request.Name));
    if (productKind is null) return Results.NotFound();

    productKind.Name = request.Name;

    await context.SaveChangesAsync();

    return Results.NoContent();
}).WithSummary($"Updates a {nameof(ProductKind)} into the database.");
#endregion

#region Recipient
#endregion

#region Route
#endregion

#region Vehicle
#endregion

app.Run();