using Microsoft.AspNetCore.Mvc;

namespace FinanceProfile.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            service = "FinanceProfile.Api",
            status = "Healthy",
            timestamp = DateTime.UtcNow
        });
    }
}