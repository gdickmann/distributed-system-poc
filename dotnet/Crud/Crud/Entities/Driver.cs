using System.Text.Json.Serialization;

namespace Crud.Entities
{
    public class Driver
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required Guid VehicleId { get; set; }
        public required Guid CarrierId { get; set; }
        [JsonIgnore]
        public Vehicle? Vehicle { get; init; }
        [JsonIgnore]
        public Carrier? Carrier { get; init; }
        [JsonIgnore]
        public Route? Route { get; }
    }
}
