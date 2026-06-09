using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface ILeituraUseCase
{
    Task<LeituraResponse> RegistrarAsync(CriarLeituraRequest request);
    Task<IEnumerable<LeituraResponse>> ObterPorSensorAsync(int sensorId);
}
