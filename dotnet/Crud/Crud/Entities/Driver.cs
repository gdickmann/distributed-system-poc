namespace Crud.Entities
{
    public class Driver
    {
        public required Guid Id { get; init; } = Guid.NewGuid();
        public required Guid VehicleId { get; init; }
        public required Guid CarrierId { get; set; }
        public required Vehicle Vehicle { get; init; }
        public required Carrier Carrier { get; init; }
        public Route? Route { get; }
    }
}
