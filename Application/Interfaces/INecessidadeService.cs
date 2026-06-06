using SmartDisaster.Application.DTOs.Necessidade;

namespace SmartDisaster.Application.Interfaces;

public interface INecessidadeService
{
    Task<IEnumerable<NecessidadeResponseDto>> GetAllAsync();
    Task<NecessidadeResponseDto?> GetByIdAsync(int id);
    Task<NecessidadeResponseDto> CreateAsync(CreateNecessidadeDto dto);
    Task<NecessidadeResponseDto?> UpdateAsync(int id, UpdateNecessidadeDto dto);
    Task<bool> DeleteAsync(int id);
}
