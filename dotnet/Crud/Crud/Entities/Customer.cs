using System.Text.Json.Serialization;

namespace Crud.Entities
{
    public class Customer
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        [JsonIgnore]
        public Route? Route { get; }
    }
}
