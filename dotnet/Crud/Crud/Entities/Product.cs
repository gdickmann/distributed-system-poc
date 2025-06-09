namespace Crud.Entities
{
    public class Product
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required Guid ProductKindId { get; init; }
        public required ProductKind ProductKind { get; init; }
        public Route? Route { get; init; }
    }
}
