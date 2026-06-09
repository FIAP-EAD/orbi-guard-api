using System.ComponentModel.DataAnnotations;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarLeituraRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "SensorId inválido.")]
    public int SensorId { get; init; }

    [Required]
    public double Valor { get; init; }

    [Required(ErrorMessage = "Unidade é obrigatória.")]
    [MaxLength(20)]
    public string Unidade { get; init; } = null!;

    public DateTime? DataHora { get; init; }
}
