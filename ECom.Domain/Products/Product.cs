using ECom.Domain.Shared;

namespace ECom.Domain.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string SKU { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(Guid id, string sku, string name, decimal price, int stock)
    {
        Id = id;
        SKU = sku;
        Name = name;
        Price = price;
        Stock = stock;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name)) throw new DomainException("Product name required");
        if (Price < 0) throw new DomainException("Price cannot be negative");
        if (Stock < 0) throw new DomainException("Stock cannot be negative");
    }

    public void DecreaseStock(int qty)
    {
        if (qty <= 0) throw new DomainException("Quantity must be > 0");
        if (qty > Stock) throw new DomainException("Not enough stock");
        Stock -= qty;
    }

    // Add other domain behaviours here (ApplyDiscount, ChangePrice, etc.)
}
