using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Infrastructure.Configurations;

public class VoluntarioConfiguration : IEntityTypeConfiguration<Voluntario>
{
    public void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        builder.ToTable("Voluntarios");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(v => v.Email)
            .IsUnique();

        builder.Property(v => v.Telefone)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(v => v.Doacoes)
            .WithOne(d => d.Voluntario)
            .HasForeignKey(d => d.VoluntarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
