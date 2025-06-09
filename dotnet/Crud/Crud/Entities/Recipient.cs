namespace Crud.Entities
{
    public class Recipient
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; init; }
        public Route? Route { get; init; }
    }
}
