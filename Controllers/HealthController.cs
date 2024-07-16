using Microsoft.AspNetCore.Mvc;

namespace AccountTransferer.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet(Name = "Health")]
    public IActionResult Health()
    {
        return Ok("Healthy");
    }
}