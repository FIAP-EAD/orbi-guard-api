using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class LeituraRepository(AppDbContext context) : ILeituraRepository
{
    public async Task<Leitura> SalvarAsync(Leitura leitura)
    {
        context.Leituras.Add(leitura);
        await context.SaveChangesAsync();
        return leitura;
    }

    public async Task<IEnumerable<Leitura>> ObterPorSensorAsync(int sensorId) =>
        await context.Leituras
            .Where(l => l.SensorId == sensorId)
            .OrderByDescending(l => l.DataHora)
            .ToListAsync();
}
