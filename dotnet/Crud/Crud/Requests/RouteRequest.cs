namespace Crud.Requests
{
    public record RouteRequest(string Name,
        Guid DriverId,
        Guid CustomerId,
        Guid RecipientId,
        Guid ProductId);
}
