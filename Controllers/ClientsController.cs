using Lab08_MattiasMarquez.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_MattiasMarquez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _service;

    public ClientsController(IClientService service)
    {
        _service = service;
    }

    [HttpGet("filter-by-name")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await _service.GetFilteredClientsAsync(name);
        return Ok(result);
    }
}