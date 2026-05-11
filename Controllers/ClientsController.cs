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

    [HttpGet] 
    public async Task<IActionResult> Search([FromQuery] string name)
    {
        var result = await _service.SearchByNameAsync(name);
        return Ok(result);
    }
}