using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/sensores")]
[Authorize]
public class SensoresController(ISensorUseCase sensorUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterTodos() =>
        Ok(await sensorUseCase.ObterTodosAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId(int id) =>
        Ok(await sensorUseCase.ObterPorIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarSensorRequest request)
    {
        var response = await sensorUseCase.CriarAsync(request);
        return CreatedAtAction(nameof(ObterPorId), new { id = response.Id }, response);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Deletar(int id)
    {
        await sensorUseCase.DeletarAsync(id);
        return NoContent();
    }
}
