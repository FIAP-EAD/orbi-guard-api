using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class AlertaRepository(AppDbContext context) : IAlertaRepository
{
    public async Task<Alerta> SalvarAsync(Alerta alerta)
    {
        context.Alertas.Add(alerta);
        await context.SaveChangesAsync();
        return alerta;
    }

    public async Task<IEnumerable<Alerta>> ObterTodosAsync() =>
        await context.Alertas.OrderByDescending(a => a.CriadoEm).ToListAsync();

    public async Task<IEnumerable<Alerta>> ObterAtivosAsync() =>
        await context.Alertas.Where(a => a.Ativo).ToListAsync();
}
