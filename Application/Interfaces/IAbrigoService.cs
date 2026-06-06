using SmartDisaster.Application.DTOs.Abrigo;

namespace SmartDisaster.Application.Interfaces;

public interface IAbrigoService
{
    Task<IEnumerable<AbrigoResponseDto>> GetAllAsync();
    Task<AbrigoResponseDto?> GetByIdAsync(int id);
    Task<AbrigoResponseDto> CreateAsync(CreateAbrigoDto dto);
    Task<AbrigoResponseDto?> UpdateAsync(int id, UpdateAbrigoDto dto);
    Task<bool> DeleteAsync(int id);
}
