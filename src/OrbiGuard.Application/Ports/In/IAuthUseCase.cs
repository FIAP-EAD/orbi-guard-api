using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface IAuthUseCase
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RegistrarAsync(RegisterRequest request);
}
