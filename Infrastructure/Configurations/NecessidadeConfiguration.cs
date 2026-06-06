using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Infrastructure.Configurations;

public class NecessidadeConfiguration : IEntityTypeConfiguration<Necessidade>
{
    public void Configure(EntityTypeBuilder<Necessidade> builder)
    {
        builder.ToTable("Necessidades");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Tipo)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(n => n.QuantidadeNecessaria)
            .IsRequired();

        builder.Property(n => n.Prioridade)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(n => n.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(n => n.AbrigoId)
            .IsRequired();
    }
}
