using System.ComponentModel.DataAnnotations;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarAlertaRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "OcorrenciaId inválido.")]
    public int OcorrenciaId { get; init; }

    [Required(ErrorMessage = "Mensagem é obrigatória.")]
    [MaxLength(500)]
    public string Mensagem { get; init; } = null!;

    [Required]
    public NivelAlerta Nivel { get; init; }
}
