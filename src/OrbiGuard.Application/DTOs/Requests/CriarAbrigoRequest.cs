namespace OrbiGuard.Application.DTOs.Requests;

public record CriarAbrigoRequest(string Nome, int Capacidade, double Latitude, double Longitude);
