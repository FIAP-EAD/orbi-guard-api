using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface IAbrigoUseCase
{
    Task<AbrigoResponse> CriarAsync(CriarAbrigoRequest request);
    Task<IEnumerable<AbrigoResponse>> ObterTodosAsync();
    Task<IEnumerable<AbrigoResponse>> ObterDisponiveisAsync();
    Task<AbrigoResponse> AtualizarOcupacaoAsync(int id, AtualizarOcupacaoRequest request);
}
