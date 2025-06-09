namespace Crud.Entities
{
    public class Customer
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Route? Route { get; }
    }
}
