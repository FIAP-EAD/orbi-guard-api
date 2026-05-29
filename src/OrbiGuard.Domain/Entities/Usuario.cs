using OrbiGuard.Domain.Enums;

namespace OrbiGuard.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string SenhaHash { get; private set; }
    public PerfilUsuario Perfil { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public Usuario(string nome, string email, string senhaHash, PerfilUsuario perfil)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail é obrigatório.");
        if (string.IsNullOrWhiteSpace(senhaHash)) throw new ArgumentException("Senha é obrigatória.");

        Nome = nome;
        Email = email.ToLowerInvariant();
        SenhaHash = senhaHash;
        Perfil = perfil;
        CriadoEm = DateTime.UtcNow;
    }

    public void AlterarSenha(string novaSenhaHash)
    {
        if (string.IsNullOrWhiteSpace(novaSenhaHash)) throw new ArgumentException("Senha inválida.");
        SenhaHash = novaSenhaHash;
    }
}
