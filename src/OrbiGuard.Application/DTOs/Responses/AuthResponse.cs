using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.DTOs.Responses;

public record AuthResponse(string Token, int UsuarioId, string Nome, PerfilUsuario Perfil);
