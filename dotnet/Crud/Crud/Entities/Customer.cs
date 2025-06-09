namespace Crud.Entities
{
    public class Customer
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Route? Route { get; }
    }
}
