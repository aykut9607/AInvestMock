using FinancialIQ.Api.Application.Abstract;
using FinancialIQ.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinancialIQ.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinancialIqResultsController : ControllerBase
{
    private readonly IFinancialIqService _financialIqService;

    public FinancialIqResultsController(IFinancialIqService financialIqService)
    {
        _financialIqService = financialIqService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _financialIqService.GetAllAsync();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] FinancialIqResult financialIqResult)
    {
        var result = await _financialIqService.AddAsync(financialIqResult);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}