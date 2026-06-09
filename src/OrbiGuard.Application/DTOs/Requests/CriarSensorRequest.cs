using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarSensorRequest(TipoSensor Tipo, string Localizacao, double Latitude, double Longitude);
