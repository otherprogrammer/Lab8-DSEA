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

    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensive()
    {
        var product = await _service.GetMostExpensiveAsync();
        if (product == null) return NotFound("No hay productos.");
        return Ok(product);
    }

    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _service.GetAveragePriceAsync();
        return Ok(new { AveragePrice = average });
    }

    [HttpGet("no-description")]
    public async Task<IActionResult> GetNoDescription()
    {
        var result = await _service.GetMissingDescriptionsAsync();
        return Ok(result);
    }

    [HttpGet("{productId}/clients")]
    public async Task<IActionResult> GetClientsByProduct(int productId)
    {
        var result = await _service.GetBuyersByProductIdAsync(productId);
        return Ok(result);
    }
}