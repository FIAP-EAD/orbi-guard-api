using System.ComponentModel.DataAnnotations;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarOcorrenciaRequest
{
    [Required]
    public TipoOcorrencia Tipo { get; init; }

    [Required]
    public GravidadeOcorrencia Gravidade { get; init; }

    [Required(ErrorMessage = "Localização é obrigatória.")]
    [MaxLength(200)]
    public string Localizacao { get; init; } = null!;

    [Range(-90, 90, ErrorMessage = "Latitude inválida.")]
    public double Latitude { get; init; }

    [Range(-180, 180, ErrorMessage = "Longitude inválida.")]
    public double Longitude { get; init; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    [MaxLength(500)]
    public string Descricao { get; init; } = null!;
}
