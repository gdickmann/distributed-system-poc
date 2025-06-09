namespace Crud.Requests
{
    public record DriverRequest(string Name, Guid VehicleId, Guid CarrierId);
}
