using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Services;

namespace OrbiGuard.Application.UseCases;

public class LeituraService(
    ILeituraRepository leituraRepo,
    ISensorRepository sensorRepo,
    IOcorrenciaRepository ocorrenciaRepo,
    IAlertaRepository alertaRepo,
    INotificationPort notification,
    AlertOrchestrator alertOrchestrator) : ILeituraUseCase
{
    public async Task<LeituraResponse> RegistrarAsync(CriarLeituraRequest request)
    {
        var sensor = await sensorRepo.ObterPorIdAsync(request.SensorId)
            ?? throw new NaoEncontradoException($"Sensor {request.SensorId} não encontrado.");

        var leitura = new Leitura(request.SensorId, request.Valor, request.Unidade, request.DataHora);
        var salva = await leituraRepo.SalvarAsync(leitura);

        var resultado = alertOrchestrator.ProcessarLeitura(salva, sensor);
        if (resultado.HasValue)
        {
            var (ocorrencia, alertaInfo) = resultado.Value;
            var ocorrenciaSalva = await ocorrenciaRepo.SalvarAsync(ocorrencia);

            var alerta = new Alerta(ocorrenciaSalva.Id, alertaInfo.Mensagem, alertaInfo.Nivel);
            await alertaRepo.SalvarAsync(alerta);
            await notification.EnviarAlertaAsync(alertaInfo.Mensagem, alertaInfo.Nivel, sensor.Localizacao);
        }

        return new LeituraResponse(salva.Id, salva.SensorId, salva.Valor, salva.Unidade, salva.DataHora);
    }

    public async Task<IEnumerable<LeituraResponse>> ObterPorSensorAsync(int sensorId) =>
        (await leituraRepo.ObterPorSensorAsync(sensorId))
            .Select(l => new LeituraResponse(l.Id, l.SensorId, l.Valor, l.Unidade, l.DataHora));
}
