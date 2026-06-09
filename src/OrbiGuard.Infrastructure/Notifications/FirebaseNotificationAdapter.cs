using Microsoft.Extensions.Logging;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Infrastructure.Notifications;

public class FirebaseNotificationAdapter(ILogger<FirebaseNotificationAdapter> logger) : INotificationPort
{
    public Task EnviarAlertaAsync(string mensagem, NivelAlerta nivel, string localizacao)
    {
        logger.LogInformation("[FCM] [{Nivel}] {Mensagem} — {Localizacao}", nivel, mensagem, localizacao);
        return Task.CompletedTask;
    }
}
