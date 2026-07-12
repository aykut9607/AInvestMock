using FinancialIQ.Api.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialIQ.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly FinancialIqDbContext  _context;

    public HealthController(FinancialIqDbContext  context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            service = "FinancialIQ.Api",
            status = "Healthy",
            timestamp = DateTime.UtcNow
        });
    }


    [HttpGet("db-check")]
    public async Task<IActionResult> DbCheck()
    {
        var count = await _context.FinancialIqResults.CountAsync();
        var users = await _context.FinancialIqResults
            .Select(p => p.UserId)
            .ToListAsync();

        return Ok(new { count, users });
    }
}