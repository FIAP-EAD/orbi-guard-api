namespace OrbiGuard.Application.DTOs.Responses;

public record LeituraResponse(int Id, int SensorId, double Valor, string Unidade, DateTime DataHora);
