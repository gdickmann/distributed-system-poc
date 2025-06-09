using System.Text.Json.Serialization;

namespace Crud.Entities
{
    public class Product
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required Guid ProductKindId { get; set; }
        [JsonIgnore]
        public ProductKind? ProductKind { get; init; }
        [JsonIgnore]
        public Route? Route { get; init; }
    }
}
