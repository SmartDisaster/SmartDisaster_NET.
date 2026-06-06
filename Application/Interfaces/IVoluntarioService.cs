using SmartDisaster.Application.DTOs.Voluntario;

namespace SmartDisaster.Application.Interfaces;

public interface IVoluntarioService
{
    Task<IEnumerable<VoluntarioResponseDto>> GetAllAsync();
    Task<VoluntarioResponseDto?> GetByIdAsync(int id);
    Task<VoluntarioResponseDto> CreateAsync(CreateVoluntarioDto dto);
    Task<VoluntarioResponseDto?> UpdateAsync(int id, UpdateVoluntarioDto dto);
    Task<bool> DeleteAsync(int id);
}
