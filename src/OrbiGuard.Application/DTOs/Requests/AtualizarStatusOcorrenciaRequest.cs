using System.ComponentModel.DataAnnotations;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record AtualizarStatusOcorrenciaRequest
{
    [Required]
    [EnumDataType(typeof(StatusOcorrencia))]
    public StatusOcorrencia Status { get; init; }
}
