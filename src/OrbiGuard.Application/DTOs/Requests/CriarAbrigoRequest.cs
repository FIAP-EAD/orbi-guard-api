using System.ComponentModel.DataAnnotations;

namespace OrbiGuard.Application.DTOs.Requests;

public record CriarAbrigoRequest
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MaxLength(200)]
    public string Nome { get; init; } = null!;

    [Required]
    [Range(1, 10000, ErrorMessage = "Capacidade deve ser entre 1 e 10000.")]
    public int Capacidade { get; init; }

    [Range(-90, 90, ErrorMessage = "Latitude inválida.")]
    public double Latitude { get; init; }

    [Range(-180, 180, ErrorMessage = "Longitude inválida.")]
    public double Longitude { get; init; }
}
