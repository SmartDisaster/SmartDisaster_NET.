using Microsoft.EntityFrameworkCore;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Infrastructure.Configurations;

namespace SmartDisaster.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Abrigo> Abrigos { get; set; }
    public DbSet<Necessidade> Necessidades { get; set; }
    public DbSet<Voluntario> Voluntarios { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AbrigoConfiguration());
        modelBuilder.ApplyConfiguration(new NecessidadeConfiguration());
        modelBuilder.ApplyConfiguration(new VoluntarioConfiguration());
        modelBuilder.ApplyConfiguration(new DoacaoConfiguration());
    }
}
