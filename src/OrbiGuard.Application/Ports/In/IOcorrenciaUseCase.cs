using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface IOcorrenciaUseCase
{
    Task<OcorrenciaResponse> CriarAsync(CriarOcorrenciaRequest request);
    Task<IEnumerable<OcorrenciaResponse>> ObterTodosAsync();
    Task<OcorrenciaResponse> ObterPorIdAsync(int id);
    Task<OcorrenciaResponse> AtualizarStatusAsync(int id, AtualizarStatusOcorrenciaRequest request);
}
