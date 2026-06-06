using Microsoft.EntityFrameworkCore;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Infrastructure.Data;

namespace SmartDisaster.Infrastructure.Repositories;

public class NecessidadeRepository : Repository<Necessidade>, INecessidadeRepository
{
    public NecessidadeRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Necessidade>> GetAllWithRelationsAsync()
        => await _context.Necessidades
            .Include(n => n.Abrigo)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Necessidade?> GetByIdWithRelationsAsync(int id)
        => await _context.Necessidades
            .Include(n => n.Abrigo)
            .FirstOrDefaultAsync(n => n.Id == id);
}
