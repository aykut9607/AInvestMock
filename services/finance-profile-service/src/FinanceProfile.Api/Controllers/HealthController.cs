using FinanceProfile.Api.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceProfile.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly FinanceDbContext _context;

    public HealthController(FinanceDbContext context)
    {
        _context = context;
    }

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

    // GEÇİCİ - sadece PostgreSQL bağlantısını gözle doğrulamak için, yarın silinecek
    [HttpGet("db-check")]
    public async Task<IActionResult> DbCheck()
    {
        var count = await _context.FinancialProfiles.CountAsync();
        var users = await _context.FinancialProfiles
            .Select(p => p.UserId)
            .ToListAsync();

        return Ok(new { count, users });
    }
}