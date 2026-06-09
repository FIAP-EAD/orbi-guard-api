using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrbiGuard.Domain.Entities;

namespace OrbiGuard.Infrastructure.Persistence.Mappings;

public class SensorMapping : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.ToTable("sensores");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.Tipo).HasConversion<string>().IsRequired();
        builder.Property(s => s.Status).HasConversion<string>().IsRequired();
        builder.Property(s => s.Localizacao).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Latitude).IsRequired();
        builder.Property(s => s.Longitude).IsRequired();
        builder.Property(s => s.CriadoEm).IsRequired();
    }
}
