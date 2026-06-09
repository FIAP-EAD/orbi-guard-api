using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Application.UseCases;

public class AlertaService(IAlertaRepository alertaRepo, IOcorrenciaRepository ocorrenciaRepo) : IAlertaUseCase
{
    public async Task<AlertaResponse> CriarAsync(CriarAlertaRequest request)
    {
        _ = await ocorrenciaRepo.ObterPorIdAsync(request.OcorrenciaId)
            ?? throw new NaoEncontradoException($"Ocorrência {request.OcorrenciaId} não encontrada.");

        var alerta = new Alerta(request.OcorrenciaId, request.Mensagem, request.Nivel);
        var salvo = await alertaRepo.SalvarAsync(alerta);
        return ToResponse(salvo);
    }

    public async Task<IEnumerable<AlertaResponse>> ObterTodosAsync() =>
        (await alertaRepo.ObterTodosAsync()).Select(ToResponse);

    public async Task<IEnumerable<AlertaResponse>> ObterAtivosAsync() =>
        (await alertaRepo.ObterAtivosAsync()).Select(ToResponse);

    private static AlertaResponse ToResponse(Alerta a) =>
        new(a.Id, a.OcorrenciaId, a.Mensagem, a.Nivel, a.Ativo, a.CriadoEm);
}
