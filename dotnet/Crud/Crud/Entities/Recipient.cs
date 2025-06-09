using System.Text.Json.Serialization;

namespace Crud.Entities
{
    public class Recipient
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        [JsonIgnore]
        public Route? Route { get; init; }
    }
}
