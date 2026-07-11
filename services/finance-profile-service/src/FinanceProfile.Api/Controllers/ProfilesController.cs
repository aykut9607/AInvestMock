using FinanceProfile.Api.Application.Abstract;
using FinanceProfile.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceProfile.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private readonly IFinancialProfileService _financialProfileService;

    public ProfilesController(IFinancialProfileService financialProfileService)
    {
        _financialProfileService = financialProfileService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _financialProfileService.GetAllAsync();

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] FinancialProfile financialProfile)
    {
        var result = await _financialProfileService.AddAsync(financialProfile);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}