using Microsoft.EntityFrameworkCore;
using OrbiGuard.Application.Ports.Out;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public Task<Usuario?> ObterPorEmailAsync(string email) =>
        context.Usuarios.FirstOrDefaultAsync(u => u.Email == email.ToLowerInvariant());

    public Task<Usuario?> ObterPorIdAsync(int id) =>
        context.Usuarios.FindAsync(id).AsTask();

    public async Task<Usuario> SalvarAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }
}
