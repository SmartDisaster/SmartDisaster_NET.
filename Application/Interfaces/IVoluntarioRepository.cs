using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Interfaces;

public interface IVoluntarioRepository : IRepository<Voluntario>
{
    Task<IEnumerable<Voluntario>> GetAllWithRelationsAsync();
    Task<Voluntario?> GetByIdWithRelationsAsync(int id);
}
