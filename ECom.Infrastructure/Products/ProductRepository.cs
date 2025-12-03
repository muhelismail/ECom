
using ECom.Application.Products;
using ECom.Domain.Products;

public class ProductRepository : IProductRepository
{
    private readonly EComDbContext _db;
    public ProductRepository(EComDbContext db) => _db = db;

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        var entity = new ProductEntity { Id = product.Id, SKU = product.SKU, Name = product.Name, Price = product.Price, Stock = product.Stock };
        _db.Products.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var e = await _db.Products.FindAsync(new object[] { id }, ct);
        if (e == null) return null;
        return new Product(e.Id, e.SKU, e.Name, e.Price, e.Stock);
    }

    public Task<IEnumerable<Product>> SearchAsync(string? nameOrSku, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
