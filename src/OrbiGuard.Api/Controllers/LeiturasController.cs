using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/leituras")]
[Authorize]
public class LeiturasController(ILeituraUseCase leituraUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] CriarLeituraRequest request)
    {
        var response = await leituraUseCase.RegistrarAsync(request);
        return Created(string.Empty, response);
    }

    [HttpGet("sensor/{sensorId:int}")]
    public async Task<IActionResult> ObterPorSensor(int sensorId) =>
        Ok(await leituraUseCase.ObterPorSensorAsync(sensorId));
}
