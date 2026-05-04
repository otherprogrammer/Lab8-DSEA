using Lab08_MattiasMarquez.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_MattiasMarquez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("filter-by-price")]
    public async Task<IActionResult> GetByPrice([FromQuery] decimal price)
    {
        var result = await _service.GetProductsHigherThanPriceAsync(price);
        return Ok(result);
    }
}