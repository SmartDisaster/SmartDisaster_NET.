using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Interfaces;

public interface IDoacaoRepository : IRepository<Doacao>
{
    Task<IEnumerable<Doacao>> GetAllWithRelationsAsync();
    Task<Doacao?> GetByIdWithRelationsAsync(int id);
}
