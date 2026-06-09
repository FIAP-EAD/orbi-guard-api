using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Requests;

public record RegisterRequest(string Nome, string Email, string Senha, PerfilUsuario Perfil);
