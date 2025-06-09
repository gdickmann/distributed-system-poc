namespace Crud.Entities
{
    public class Route
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; init; }
        public required Guid DriverId { get; init; }
        public required Guid CustomerId { get; init; }
        public required Guid RecipientId { get; init; }
        public required Guid ProductId { get; init; }
        public required Driver Driver { get; init; }
        public required Customer Customer { get; init; }
        public required Recipient Recipient { get; init; }
        public required Product Product { get; init; }
    }
}
