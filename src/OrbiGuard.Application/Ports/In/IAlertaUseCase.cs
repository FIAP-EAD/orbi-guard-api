using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface IAlertaUseCase
{
    Task<AlertaResponse> CriarAsync(CriarAlertaRequest request);
    Task<IEnumerable<AlertaResponse>> ObterTodosAsync();
    Task<IEnumerable<AlertaResponse>> ObterAtivosAsync();
}
