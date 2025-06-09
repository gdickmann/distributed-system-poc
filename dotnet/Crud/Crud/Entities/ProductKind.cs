namespace Crud.Entities
{
    public class ProductKind
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; init; }
        public Product? Product { get; init; }
    }
}
