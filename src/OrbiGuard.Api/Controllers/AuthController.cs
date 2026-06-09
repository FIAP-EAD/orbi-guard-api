using Microsoft.AspNetCore.Mvc;
using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.Ports.In;

namespace OrbiGuard.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthUseCase authUseCase) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await authUseCase.LoginAsync(request);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await authUseCase.RegistrarAsync(request);
        return CreatedAtAction(nameof(Login), response);
    }
}
