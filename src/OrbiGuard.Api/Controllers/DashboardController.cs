using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController(IDashboardUseCase dashboardUseCase) : ControllerBase
{
    [HttpGet("risco")]
    public async Task<IActionResult> ObterRisco() =>
        Ok(await dashboardUseCase.ObterRiscoAsync());
}
