using OrbiGuard.Application.DTOs.Requests;
using OrbiGuard.Application.DTOs.Responses;
using OrbiGuard.Application.Exceptions;
using OrbiGuard.Application.Ports.In;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;
using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Application.UseCases;

public class AuthService(IUsuarioRepository usuarioRepo, IJwtPort jwt, IPasswordHasher hasher) : IAuthUseCase
{
    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var usuario = await usuarioRepo.ObterPorEmailAsync(request.Email)
            ?? throw new NaoAutorizadoException("Credenciais inválidas.");

        if (!hasher.Verificar(request.Senha, usuario.SenhaHash))
            throw new NaoAutorizadoException("Credenciais inválidas.");

        return new AuthResponse(jwt.GerarToken(usuario), usuario.Id, usuario.Nome, usuario.Perfil);
    }

    public async Task<AuthResponse> RegistrarAsync(RegisterRequest request)
    {
        if (await usuarioRepo.ObterPorEmailAsync(request.Email) is not null)
            throw new ConflitoException("E-mail já cadastrado.");

        // Perfil fixado em Usuario — elevação de privilégio exige endpoint admin dedicado.
        var usuario = new Usuario(request.Nome, request.Email, hasher.Hash(request.Senha), PerfilUsuario.Usuario);
        var salvo = await usuarioRepo.SalvarAsync(usuario);

        return new AuthResponse(jwt.GerarToken(salvo), salvo.Id, salvo.Nome, salvo.Perfil);
    }
}
