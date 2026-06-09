using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarOcorrenciaRequest(
    TipoOcorrencia Tipo,
    GravidadeOcorrencia Gravidade,
    string Localizacao,
    double Latitude,
    double Longitude,
    string Descricao);
