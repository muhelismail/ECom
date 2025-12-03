// Project: ECom.Api
using ECom.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Api.Areas.Manager;

[ApiController]
[Route("api/v1/products")]
public class ProductsController(GetProductByIdHandler handler) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken ct)
    {
        var dto = await handler.Handle(new GetProductByIdQuery { Id = id }, ct);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
