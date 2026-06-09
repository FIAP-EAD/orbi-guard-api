using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Mappings;

public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
{
    public void Configure(EntityTypeBuilder<Ocorrencia> builder)
    {
        builder.ToTable("ocorrencias");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
        builder.Property(o => o.Tipo).HasConversion<string>().IsRequired();
        builder.Property(o => o.Gravidade).HasConversion<string>().IsRequired();
        builder.Property(o => o.Status).HasConversion<string>().IsRequired();
        builder.Property(o => o.Localizacao).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Latitude).IsRequired();
        builder.Property(o => o.Longitude).IsRequired();
        builder.Property(o => o.Descricao).IsRequired().HasMaxLength(500);
        builder.Property(o => o.DataHora).IsRequired();
    }
}
