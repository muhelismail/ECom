
using ECom.Application.Products;
using ECom.Domain.Products;
using ECom.Infrastructure.Data;
using ECom.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class ProductRepository(EComDbContext _context) : IProductRepository
{
    // Mapping Domain -> Entity
    private static ProductEntity ToEntity(Product domain) => new()
    {
        Id = domain.Id,
        SKU = domain.SKU,
        Name = domain.Name,
        Price = domain.Price,
        Stock = domain.Stock
    };

    // Mapping Entity -> Domain
    private static Product ToDomain(ProductEntity entity) => new(
        entity.Id,
        entity.SKU,
        entity.Name,
        entity.Price,
        entity.Stock
    );

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var entities = await _context.Products.ToListAsync();
        return entities.Select(ToDomain);
    }


    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Products.FindAsync(id);

        if (entity != null)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Products.AnyAsync(x => x.Id == id);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Products.FindAsync([id], cancellationToken: ct);
        return entity == null ? null : ToDomain(entity);
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        var entity = ToEntity(product);
        await _context.Products.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        var entity = ToEntity(product);
        _context.Products.Update(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Product>> SearchAsync(string? nameOrSku,
        CancellationToken ct = default)
    {
        var entities = await _context.Products.ToListAsync(cancellationToken: ct);
        return entities.Select(ToDomain);
    }
}
