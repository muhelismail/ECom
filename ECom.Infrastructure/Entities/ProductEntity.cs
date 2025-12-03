namespace ECom.Infrastructure.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
