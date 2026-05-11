using Lab08_MattiasMarquez.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_MattiasMarquez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IOrderDetailService _orderDetailService;

    public OrdersController(IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderService = orderService;
        _orderDetailService = orderDetailService;
    }

    [HttpGet("{orderId}/items")]
    public async Task<IActionResult> GetDetails(int orderId)
    {
        var result = await _orderDetailService.GetOrderDetailsAsync(orderId);
        return Ok(result);
    }

    [HttpGet("{orderId}/quantity")]
    public async Task<IActionResult> GetTotalQuantity(int orderId)
    {
        var total = await _orderService.GetTotalQuantityAsync(orderId);
        return Ok(new { OrderId = orderId, TotalProducts = total });
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] DateTime? since)
    {
        if (since.HasValue)
        {
            var orders = await _orderService.GetOrdersRecentAsync(since.Value);
            return Ok(orders);
        }
        return BadRequest(new { error = "A valid date is required" });
    }

    [HttpGet("statistics/top-client")]
    public async Task<IActionResult> GetTopClient()
    {
        var result = await _orderService.GetTopClientAsync();
        return Ok(result);
    }

    [HttpGet("by-client/{clientId}/products")]
    public async Task<IActionResult> GetProductsByClient(int clientId)
    {
        var result = await _orderService.GetProductNamesByClientAsync(clientId);
        return Ok(result);
    }

    [HttpGet("items")]
    public async Task<IActionResult> GetAllDetails()
    {
        var result = await _orderDetailService.GetAllDetailsProjectedAsync();
        return Ok(result);
    }
}