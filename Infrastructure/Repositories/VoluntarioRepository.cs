using Microsoft.EntityFrameworkCore;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;
using SmartDisaster.Infrastructure.Data;

namespace SmartDisaster.Infrastructure.Repositories;

public class VoluntarioRepository : Repository<Voluntario>, IVoluntarioRepository
{
    public VoluntarioRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Voluntario>> GetAllWithRelationsAsync()
        => await _context.Voluntarios
            .Include(v => v.Doacoes)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Voluntario?> GetByIdWithRelationsAsync(int id)
        => await _context.Voluntarios
            .Include(v => v.Doacoes)
            .FirstOrDefaultAsync(v => v.Id == id);
}
