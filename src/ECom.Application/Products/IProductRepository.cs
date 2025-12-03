using ECom.Domain.Products;

namespace ECom.Application.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
    Task UpdateAsync(Product product, CancellationToken ct = default);
    Task<IEnumerable<Product>> SearchAsync(string? nameOrSku, CancellationToken ct = default);
}
