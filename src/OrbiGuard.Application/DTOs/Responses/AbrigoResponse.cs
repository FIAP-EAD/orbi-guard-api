namespace OrbiGuard.Application.DTOs.Responses;

public record AbrigoResponse(int Id, string Nome, int Capacidade, int OcupacaoAtual, int VagasDisponiveis, bool Disponivel, double Latitude, double Longitude);
