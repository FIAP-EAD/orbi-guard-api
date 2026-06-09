using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Application.UseCases;

public class AbrigoService(IAbrigoRepository abrigoRepo) : IAbrigoUseCase
{
    public async Task<AbrigoResponse> CriarAsync(CriarAbrigoRequest request)
    {
        var abrigo = new Abrigo(request.Nome, request.Capacidade, request.Latitude, request.Longitude);
        var salvo = await abrigoRepo.SalvarAsync(abrigo);
        return ToResponse(salvo);
    }

    public async Task<IEnumerable<AbrigoResponse>> ObterTodosAsync() =>
        (await abrigoRepo.ObterTodosAsync()).Select(ToResponse);

    public async Task<IEnumerable<AbrigoResponse>> ObterDisponiveisAsync() =>
        (await abrigoRepo.ObterDisponiveisAsync()).Select(ToResponse);

    public async Task<AbrigoResponse> AtualizarOcupacaoAsync(int id, AtualizarOcupacaoRequest request)
    {
        var abrigo = await abrigoRepo.ObterPorIdAsync(id)
            ?? throw new NaoEncontradoException($"Abrigo {id} não encontrado.");

        abrigo.AtualizarOcupacao(request.OcupacaoAtual);
        var atualizado = await abrigoRepo.AtualizarAsync(abrigo);
        return ToResponse(atualizado);
    }

    private static AbrigoResponse ToResponse(Abrigo a) =>
        new(a.Id, a.Nome, a.Capacidade, a.OcupacaoAtual, a.VagasDisponiveis, a.Disponivel, a.Latitude, a.Longitude);
}
