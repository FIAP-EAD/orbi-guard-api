using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Responses;

public record SensorResponse(int Id, TipoSensor Tipo, StatusSensor Status, string Localizacao, double Latitude, double Longitude);
