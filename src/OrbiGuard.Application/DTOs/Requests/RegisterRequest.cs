using System.ComponentModel.DataAnnotations;

namespace OrbiGuard.Application.DTOs.Requests;

public record RegisterRequest
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MaxLength(150)]
    public string Nome { get; init; } = null!;

    [Required(ErrorMessage = "E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [MaxLength(200)]
    public string Email { get; init; } = null!;

    [Required(ErrorMessage = "Senha é obrigatória.")]
    [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres.")]
    [MaxLength(100)]
    public string Senha { get; init; } = null!;

    // Perfil removido: novos usuários são sempre registrados como Usuario.
    // Elevação de privilégio é feita por endpoint admin dedicado.
}
