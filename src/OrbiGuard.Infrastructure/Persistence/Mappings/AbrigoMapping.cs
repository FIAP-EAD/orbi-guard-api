using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Mappings;

public class AbrigoMapping : IEntityTypeConfiguration<Abrigo>
{
    public void Configure(EntityTypeBuilder<Abrigo> builder)
    {
        builder.ToTable("abrigos");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Nome).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Capacidade).IsRequired();
        builder.Property(a => a.OcupacaoAtual).IsRequired();
        builder.Property(a => a.Latitude).IsRequired();
        builder.Property(a => a.Longitude).IsRequired();
        builder.Ignore(a => a.Disponivel);
        builder.Ignore(a => a.VagasDisponiveis);
    }
}
