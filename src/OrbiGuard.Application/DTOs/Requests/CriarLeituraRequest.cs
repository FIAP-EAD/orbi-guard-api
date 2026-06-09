namespace OrbiGuard.Application.DTOs.Requests;

public record CriarLeituraRequest(int SensorId, double Valor, string Unidade, DateTime? DataHora = null);
