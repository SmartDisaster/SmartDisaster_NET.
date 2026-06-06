using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Interfaces;

public interface IAbrigoRepository : IRepository<Abrigo>
{
    Task<IEnumerable<Abrigo>> GetAllWithRelationsAsync();
    Task<Abrigo?> GetByIdWithRelationsAsync(int id);
}
