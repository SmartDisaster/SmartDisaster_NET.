using Microsoft.EntityFrameworkCore;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Infrastructure.Data;

namespace SmartDisaster.Infrastructure.Repositories;

public class AbrigoRepository : Repository<Abrigo>, IAbrigoRepository
{
    public AbrigoRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Abrigo>> GetAllWithRelationsAsync()
        => await _context.Abrigos
            .Include(a => a.Necessidades)
            .Include(a => a.Doacoes)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Abrigo?> GetByIdWithRelationsAsync(int id)
        => await _context.Abrigos
            .Include(a => a.Necessidades)
            .Include(a => a.Doacoes)
            .FirstOrDefaultAsync(a => a.Id == id);
}
