using Microsoft.EntityFrameworkCore;
using OrbiGuard.Domain.Entities;
using System.Reflection;

namespace OrbiGuard.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Sensor> Sensores => Set<Sensor>();
    public DbSet<Leitura> Leituras => Set<Leitura>();
    public DbSet<Ocorrencia> Ocorrencias => Set<Ocorrencia>();
    public DbSet<Alerta> Alertas => Set<Alerta>();
    public DbSet<Abrigo> Abrigos => Set<Abrigo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
