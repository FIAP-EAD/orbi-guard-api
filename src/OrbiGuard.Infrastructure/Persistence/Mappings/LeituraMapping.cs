using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Mappings;

public class LeituraMapping : IEntityTypeConfiguration<Leitura>
{
    public void Configure(EntityTypeBuilder<Leitura> builder)
    {
        builder.ToTable("leituras");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.SensorId).IsRequired();
        builder.Property(l => l.Valor).IsRequired();
        builder.Property(l => l.Unidade).IsRequired().HasMaxLength(20);
        builder.Property(l => l.DataHora).IsRequired();
    }
}
