using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class OcorrenciaRepository(AppDbContext context) : IOcorrenciaRepository
{
    public Task<Ocorrencia?> ObterPorIdAsync(int id) =>
        context.Ocorrencias.FindAsync(id).AsTask();

    public async Task<IEnumerable<Ocorrencia>> ObterTodosAsync() =>
        await context.Ocorrencias.OrderByDescending(o => o.DataHora).ToListAsync();

    public async Task<IEnumerable<Ocorrencia>> ObterAbertasAsync() =>
        await context.Ocorrencias
            .Where(o => o.Status == StatusOcorrencia.Aberta || o.Status == StatusOcorrencia.EmAtendimento)
            .ToListAsync();

    public async Task<Ocorrencia> SalvarAsync(Ocorrencia ocorrencia)
    {
        context.Ocorrencias.Add(ocorrencia);
        await context.SaveChangesAsync();
        return ocorrencia;
    }

    public async Task<Ocorrencia> AtualizarAsync(Ocorrencia ocorrencia)
    {
        await context.SaveChangesAsync();
        return ocorrencia;
    }
}
