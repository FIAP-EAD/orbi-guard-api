using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/abrigos")]
[Authorize]
public class AbrigosController(IAbrigoUseCase abrigoUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterTodos() =>
        Ok(await abrigoUseCase.ObterTodosAsync());

    [HttpGet("disponiveis")]
    public async Task<IActionResult> ObterDisponiveis() =>
        Ok(await abrigoUseCase.ObterDisponiveisAsync());

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarAbrigoRequest request)
    {
        var response = await abrigoUseCase.CriarAsync(request);
        return CreatedAtAction(nameof(ObterTodos), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}/ocupacao")]
    public async Task<IActionResult> AtualizarOcupacao(int id, [FromBody] AtualizarOcupacaoRequest request)
    {
        var response = await abrigoUseCase.AtualizarOcupacaoAsync(id, request);
        return Ok(response);
    }
}
