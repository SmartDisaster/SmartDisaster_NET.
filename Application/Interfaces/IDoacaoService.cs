using SmartDisaster.Application.DTOs.Doacao;

namespace SmartDisaster.Application.Interfaces;

public interface IDoacaoService
{
    Task<IEnumerable<DoacaoResponseDto>> GetAllAsync();
    Task<DoacaoResponseDto?> GetByIdAsync(int id);
    Task<DoacaoResponseDto> CreateAsync(CreateDoacaoDto dto);
    Task<DoacaoResponseDto?> UpdateAsync(int id, UpdateDoacaoDto dto);
    Task<bool> DeleteAsync(int id);
}
