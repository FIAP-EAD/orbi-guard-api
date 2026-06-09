using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class SensorRepository(AppDbContext context) : ISensorRepository
{
    public Task<Sensor?> ObterPorIdAsync(int id) =>
        context.Sensores.FindAsync(id).AsTask();

    public async Task<IEnumerable<Sensor>> ObterTodosAsync() =>
        await context.Sensores.ToListAsync();

    public async Task<Sensor> SalvarAsync(Sensor sensor)
    {
        context.Sensores.Add(sensor);
        await context.SaveChangesAsync();
        return sensor;
    }

    public async Task DeletarAsync(int id)
    {
        var sensor = await context.Sensores.FindAsync(id);
        if (sensor is not null)
        {
            context.Sensores.Remove(sensor);
            await context.SaveChangesAsync();
        }
    }

    public Task<int> ContarAtivosAsync() =>
        context.Sensores.CountAsync(s => s.Status == StatusSensor.Ativo);
}
