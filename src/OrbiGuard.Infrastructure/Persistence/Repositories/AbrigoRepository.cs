using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class AbrigoRepository(AppDbContext context) : IAbrigoRepository
{
    public Task<Abrigo?> ObterPorIdAsync(int id) =>
        context.Abrigos.FindAsync(id).AsTask();

    public async Task<IEnumerable<Abrigo>> ObterTodosAsync() =>
        await context.Abrigos.ToListAsync();

    public async Task<IEnumerable<Abrigo>> ObterDisponiveisAsync() =>
        await context.Abrigos
            .Where(a => a.OcupacaoAtual < a.Capacidade)
            .ToListAsync();

    public async Task<Abrigo> SalvarAsync(Abrigo abrigo)
    {
        context.Abrigos.Add(abrigo);
        await context.SaveChangesAsync();
        return abrigo;
    }

    public async Task<Abrigo> AtualizarAsync(Abrigo abrigo)
    {
        context.Abrigos.Update(abrigo);
        await context.SaveChangesAsync();
        return abrigo;
    }
}
