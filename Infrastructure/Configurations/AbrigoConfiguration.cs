using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Infrastructure.Configurations;

public class AbrigoConfiguration : IEntityTypeConfiguration<Abrigo>
{
    public void Configure(EntityTypeBuilder<Abrigo> builder)
    {
        builder.ToTable("Abrigos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Estado)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(a => a.Endereco)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.CapacidadeMaxima)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(a => a.Necessidades)
            .WithOne(n => n.Abrigo)
            .HasForeignKey(n => n.AbrigoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Doacoes)
            .WithOne(d => d.Abrigo)
            .HasForeignKey(d => d.AbrigoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
