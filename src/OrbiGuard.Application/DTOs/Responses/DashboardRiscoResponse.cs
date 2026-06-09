namespace OrbiGuard.Application.DTOs.Responses;

public record DashboardRiscoResponse(
    string NivelRisco,
    int AlertasAtivos,
    int OcorrenciasAbertas,
    int AbrigosDisponiveis,
    int SensoresAtivos);
