namespace ECom.Application.Products;

public class GetProductByIdHandler
{
    private readonly IProductRepository _repo;
    public GetProductByIdHandler(IProductRepository repo) => _repo = repo;
    public async Task<ProductDto?> Handle(GetProductByIdQuery q, CancellationToken ct)
    {
        var p = await _repo.GetByIdAsync(q.Id, ct);
        if (p == null) return null;
        return new ProductDto(p.Id, p.SKU, p.Name, p.Price, p.Stock);
    }
}
