using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.UseCases;

public class OcorrenciaService(IOcorrenciaRepository ocorrenciaRepo) : IOcorrenciaUseCase
{
    public async Task<OcorrenciaResponse> CriarAsync(CriarOcorrenciaRequest request)
    {
        var ocorrencia = new Ocorrencia(
            request.Tipo, request.Gravidade, request.Localizacao,
            request.Latitude, request.Longitude, request.Descricao);
        var salva = await ocorrenciaRepo.SalvarAsync(ocorrencia);
        return ToResponse(salva);
    }

    public async Task<IEnumerable<OcorrenciaResponse>> ObterTodosAsync() =>
        (await ocorrenciaRepo.ObterTodosAsync()).Select(ToResponse);

    public async Task<OcorrenciaResponse> ObterPorIdAsync(int id)
    {
        var ocorrencia = await ocorrenciaRepo.ObterPorIdAsync(id)
            ?? throw new NaoEncontradoException($"Ocorrência {id} não encontrada.");
        return ToResponse(ocorrencia);
    }

    public async Task<OcorrenciaResponse> AtualizarStatusAsync(int id, AtualizarStatusOcorrenciaRequest request)
    {
        var ocorrencia = await ocorrenciaRepo.ObterPorIdAsync(id)
            ?? throw new NaoEncontradoException($"Ocorrência {id} não encontrada.");

        switch (request.Status)
        {
            case StatusOcorrencia.EmAtendimento: ocorrencia.IniciarAtendimento(); break;
            case StatusOcorrencia.Resolvida:     ocorrencia.Resolver();           break;
            case StatusOcorrencia.Cancelada:     ocorrencia.Cancelar();           break;
            default:
                throw new ArgumentException($"Transição para '{request.Status}' não é permitida.");
        }

        var atualizada = await ocorrenciaRepo.AtualizarAsync(ocorrencia);
        return ToResponse(atualizada);
    }

    private static OcorrenciaResponse ToResponse(Ocorrencia o) =>
        new(o.Id, o.Tipo, o.Gravidade, o.Status, o.Localizacao, o.Latitude, o.Longitude, o.Descricao, o.DataHora);
}
