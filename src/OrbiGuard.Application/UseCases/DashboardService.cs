using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;

namespace OrbiGuard.Application.UseCases;

public class DashboardService(
    IAlertaRepository alertaRepo,
    IOcorrenciaRepository ocorrenciaRepo,
    IAbrigoRepository abrigoRepo,
    ISensorRepository sensorRepo) : IDashboardUseCase
{
    public async Task<DashboardRiscoResponse> ObterRiscoAsync()
    {
        var alertasAtivos      = (await alertaRepo.ObterAtivosAsync()).Count();
        var ocorrenciasAbertas = (await ocorrenciaRepo.ObterAbertasAsync()).Count();
        var abrigosDisponiveis = (await abrigoRepo.ObterDisponiveisAsync()).Count();
        var sensoresAtivos     = await sensorRepo.ContarAtivosAsync();

        var nivelRisco = (alertasAtivos, ocorrenciasAbertas) switch
        {
            ( >= 3, _) or (_, >= 5) => "CRITICO",
            ( >= 2, _) or (_, >= 3) => "ALTO",
            ( >= 1, _) or (_, >= 1) => "ATENCAO",
            _                       => "SEGURO"
        };

        return new DashboardRiscoResponse(nivelRisco, alertasAtivos, ocorrenciasAbertas, abrigosDisponiveis, sensoresAtivos);
    }
}
