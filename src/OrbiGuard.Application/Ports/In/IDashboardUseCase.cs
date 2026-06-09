using OrbiGuard.Application.DTOs.Responses;

namespace OrbiGuard.Application.Ports.In;

public interface IDashboardUseCase
{
    Task<DashboardRiscoResponse> ObterRiscoAsync();
}
