using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Application.UseCases;
using OrbiGuard.Domain.Services;
using OrbiGuard.Infrastructure.Notifications;
using OrbiGuard.Infrastructure.Persistence;
using OrbiGuard.Infrastructure.Persistence.Repositories;
using OrbiGuard.Infrastructure.Security;

namespace OrbiGuard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ISensorRepository, SensorRepository>();
        services.AddScoped<ILeituraRepository, LeituraRepository>();
        services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
        services.AddScoped<IAlertaRepository, AlertaRepository>();
        services.AddScoped<IAbrigoRepository, AbrigoRepository>();

        services.AddScoped<IJwtPort, JwtAdapter>();
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
        services.AddScoped<INotificationPort, FirebaseNotificationAdapter>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RiskAnalyzer>();
        services.AddScoped<AlertOrchestrator>();

        services.AddScoped<IAuthUseCase, AuthService>();
        services.AddScoped<ISensorUseCase, SensorService>();
        services.AddScoped<ILeituraUseCase, LeituraService>();
        services.AddScoped<IOcorrenciaUseCase, OcorrenciaService>();
        services.AddScoped<IAlertaUseCase, AlertaService>();
        services.AddScoped<IAbrigoUseCase, AbrigoService>();
        services.AddScoped<IDashboardUseCase, DashboardService>();

        return services;
    }
}
