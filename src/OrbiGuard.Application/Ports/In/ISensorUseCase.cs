using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface ISensorUseCase
{
    Task<SensorResponse> CriarAsync(CriarSensorRequest request);
    Task<IEnumerable<SensorResponse>> ObterTodosAsync();
    Task<SensorResponse> ObterPorIdAsync(int id);
    Task DeletarAsync(int id);
}
