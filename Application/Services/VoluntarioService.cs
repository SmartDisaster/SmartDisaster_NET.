using SmartDisaster.Application.DTOs.Voluntario;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Services;

public class VoluntarioService : IVoluntarioService
{
    private readonly IVoluntarioRepository _repository;

    public VoluntarioService(IVoluntarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VoluntarioResponseDto>> GetAllAsync()
    {
        var voluntarios = await _repository.GetAllWithRelationsAsync();
        return voluntarios.Select(MapToResponseDto);
    }

    public async Task<VoluntarioResponseDto?> GetByIdAsync(int id)
    {
        var voluntario = await _repository.GetByIdWithRelationsAsync(id);
        return voluntario is null ? null : MapToResponseDto(voluntario);
    }

    public async Task<VoluntarioResponseDto> CreateAsync(CreateVoluntarioDto dto)
    {
        var voluntario = new Voluntario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        };

        await _repository.AddAsync(voluntario);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(voluntario);
    }

    public async Task<VoluntarioResponseDto?> UpdateAsync(int id, UpdateVoluntarioDto dto)
    {
        var voluntario = await _repository.GetByIdWithRelationsAsync(id);
        if (voluntario is null) return null;

        voluntario.Nome = dto.Nome;
        voluntario.Email = dto.Email;
        voluntario.Telefone = dto.Telefone;

        _repository.Update(voluntario);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(voluntario);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var voluntario = await _repository.GetByIdAsync(id);
        if (voluntario is null) return false;

        _repository.Remove(voluntario);
        await _repository.SaveChangesAsync();
        return true;
    }

    private static VoluntarioResponseDto MapToResponseDto(Voluntario v) => new()
    {
        Id = v.Id,
        Nome = v.Nome,
        Email = v.Email,
        Telefone = v.Telefone,
        TotalDoacoes = v.Doacoes?.Count ?? 0
    };
}
