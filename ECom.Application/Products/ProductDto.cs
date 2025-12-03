namespace ECom.Application.Products;

public record ProductDto(Guid Id, string SKU, string Name, decimal Price, int Stock);
