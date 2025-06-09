using System.Text.Json.Serialization;

namespace Crud.Entities
{
    public class ProductKind
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        [JsonIgnore]
        public Product? Product { get; init; }
    }
}
