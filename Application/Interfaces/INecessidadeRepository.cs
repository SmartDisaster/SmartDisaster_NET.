using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Interfaces;

public interface INecessidadeRepository : IRepository<Necessidade>
{
    Task<IEnumerable<Necessidade>> GetAllWithRelationsAsync();
    Task<Necessidade?> GetByIdWithRelationsAsync(int id);
}
