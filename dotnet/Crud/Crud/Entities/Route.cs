using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Driver? Driver { get; init; }
        [JsonIgnore]
        public Customer? Customer { get; init; }
        [JsonIgnore]
        public Recipient? Recipient { get; init; }
        [JsonIgnore]
        public Product? Product { get; init; }
    }
}
