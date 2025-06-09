namespace Crud.Entities
{
    public class Route
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required Guid DriverId { get; set; }
        public required Guid CustomerId { get; set; }
        public required Guid RecipientId { get; set; }
        public required Guid ProductId { get; set; }
        public Driver? Driver { get; init; }
        public Customer? Customer { get; init; }
        public Recipient? Recipient { get; init; }
        public Product? Product { get; init; }
    }
}
