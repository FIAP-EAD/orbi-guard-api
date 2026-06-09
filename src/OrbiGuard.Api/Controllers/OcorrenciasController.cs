using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/ocorrencias")]
[Authorize]
public class OcorrenciasController(IOcorrenciaUseCase ocorrenciaUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterTodas() =>
        Ok(await ocorrenciaUseCase.ObterTodosAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId(int id) =>
        Ok(await ocorrenciaUseCase.ObterPorIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarOcorrenciaRequest request)
    {
        var response = await ocorrenciaUseCase.CriarAsync(request);
        return CreatedAtAction(nameof(ObterPorId), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> AtualizarStatus(int id, [FromBody] AtualizarStatusOcorrenciaRequest request)
    {
        var response = await ocorrenciaUseCase.AtualizarStatusAsync(id, request);
        return Ok(response);
    }
}
