using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Mappings;

public class AlertaMapping : IEntityTypeConfiguration<Alerta>
{
    public void Configure(EntityTypeBuilder<Alerta> builder)
    {
        builder.ToTable("alertas");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.OcorrenciaId).IsRequired();
        builder.Property(a => a.Mensagem).IsRequired().HasMaxLength(500);
        builder.Property(a => a.Nivel).HasConversion<string>().IsRequired();
        builder.Property(a => a.Ativo).IsRequired();
        builder.Property(a => a.CriadoEm).IsRequired();
    }
}
