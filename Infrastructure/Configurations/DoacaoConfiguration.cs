using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Infrastructure.Configurations;

public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
{
    public void Configure(EntityTypeBuilder<Doacao> builder)
    {
        builder.ToTable("Doacoes");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Item)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Quantidade)
            .IsRequired();

        builder.Property(d => d.DataRegistro)
            .IsRequired();

        builder.Property(d => d.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(d => d.AbrigoId)
            .IsRequired();

        builder.Property(d => d.VoluntarioId)
            .IsRequired();
    }
}
