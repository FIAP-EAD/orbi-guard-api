using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/alertas")]
[Authorize]
public class AlertasController(IAlertaUseCase alertaUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterTodos() =>
        Ok(await alertaUseCase.ObterTodosAsync());

    [HttpGet("ativos")]
    public async Task<IActionResult> ObterAtivos() =>
        Ok(await alertaUseCase.ObterAtivosAsync());

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarAlertaRequest request)
    {
        var response = await alertaUseCase.CriarAsync(request);
        return Created(string.Empty, response);
    }
}
