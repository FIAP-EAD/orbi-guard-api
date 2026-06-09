using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Responses;

public record OcorrenciaResponse(
    int Id,
    TipoOcorrencia Tipo,
    GravidadeOcorrencia Gravidade,
    StatusOcorrencia Status,
    string Localizacao,
    double Latitude,
    double Longitude,
    string Descricao,
    DateTime DataHora);
