using Microsoft.EntityFrameworkCore;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Infrastructure.Data;

namespace SmartDisaster.Infrastructure.Repositories;

public class DoacaoRepository : Repository<Doacao>, IDoacaoRepository
{
    public DoacaoRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Doacao>> GetAllWithRelationsAsync()
        => await _context.Doacoes
            .Include(d => d.Abrigo)
            .Include(d => d.Voluntario)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Doacao?> GetByIdWithRelationsAsync(int id)
        => await _context.Doacoes
            .Include(d => d.Abrigo)
            .Include(d => d.Voluntario)
            .FirstOrDefaultAsync(d => d.Id == id);
}
