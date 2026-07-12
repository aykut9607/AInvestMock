using FinanceProfile.Api.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceProfile.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly FinanceDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;

    public HealthController(FinanceDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory; 
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

    [HttpGet("db-check")]
    public async Task<IActionResult> DbCheck()
    {
        var count = await _context.FinancialProfiles.CountAsync();
        var users = await _context.FinancialProfiles
            .Select(p => p.UserId)
            .ToListAsync();

        return Ok(new { count, users });
    }

    [HttpGet("iq-check")]
    public async Task<IActionResult> IqCheck()
    {
       var client = _httpClientFactory.CreateClient();
       //creates a new instance of HttpClient using the IHttpClientFactory. 

       var response = await client.GetAsync("http://localhost:5109/health");
       //making a request to the Financial IQ service's health endpoint. It waits for the response asynchronously.Just like in JS.
       
       var content = await response.Content.ReadAsStringAsync();
       return Ok(new { financeCalledIq = true, iqResponse = content });
    }
}