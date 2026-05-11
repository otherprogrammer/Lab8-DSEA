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

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] decimal? minPrice)
    {
        if (minPrice.HasValue)
        {
            var filtered = await _service.GetProductsHigherThanPriceAsync(minPrice.Value);
            return Ok(filtered);
        }
        return BadRequest(new { error = "A minimum price filter is required" });
    }

    [HttpGet("expensive/top")]
    public async Task<IActionResult> GetMostExpensive()
    {
        var product = await _service.GetMostExpensiveAsync();
        if (product == null)
        {
            return NotFound(new { message = "No products found" });
        }
        return Ok(product);
    }

    [HttpGet("statistics/average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _service.GetAveragePriceAsync();
        return Ok(new { averagePrice = average });
    }

    [HttpGet("incomplete/no-description")]
    public async Task<IActionResult> GetMissingDescriptions()
    {
        var result = await _service.GetMissingDescriptionsAsync();
        return Ok(result);
    }

    [HttpGet("{productId}/buyers")]
    public async Task<IActionResult> GetBuyersByProduct(int productId)
    {
        var result = await _service.GetBuyersByProductIdAsync(productId);
        if (!result.Any())
        {
            return NotFound(new { message = "No buyers found for this product" });
        }
        return Ok(result);
    }
}