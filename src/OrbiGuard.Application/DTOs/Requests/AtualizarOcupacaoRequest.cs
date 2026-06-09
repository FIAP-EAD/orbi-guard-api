using System.ComponentModel.DataAnnotations;

namespace OrbiGuard.Application.DTOs.Requests;

public record AtualizarOcupacaoRequest
{
    [Required]
    [Range(0, 10000, ErrorMessage = "Ocupação deve ser entre 0 e 10000.")]
    public int OcupacaoAtual { get; init; }
}
