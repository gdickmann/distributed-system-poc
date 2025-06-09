namespace Crud.Entities
{
    public class Vehicle
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Driver? Driver { get; }
    }
}
