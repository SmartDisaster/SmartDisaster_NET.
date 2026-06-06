using SmartDisaster.Application.DTOs.Abrigo;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Services;

public class AbrigoService : IAbrigoService
{
    private readonly IAbrigoRepository _repository;

    public AbrigoService(IAbrigoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AbrigoResponseDto>> GetAllAsync()
    {
        var abrigos = await _repository.GetAllWithRelationsAsync();
        return abrigos.Select(MapToResponseDto);
    }

    public async Task<AbrigoResponseDto?> GetByIdAsync(int id)
    {
        var abrigo = await _repository.GetByIdWithRelationsAsync(id);
        return abrigo is null ? null : MapToResponseDto(abrigo);
    }

    public async Task<AbrigoResponseDto> CreateAsync(CreateAbrigoDto dto)
    {
        var abrigo = new Abrigo
        {
            Nome = dto.Nome,
            Cidade = dto.Cidade,
            Estado = dto.Estado.ToUpper(),
            Endereco = dto.Endereco,
            CapacidadeMaxima = dto.CapacidadeMaxima,
            Status = dto.Status
        };

        await _repository.AddAsync(abrigo);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(abrigo);
    }

    public async Task<AbrigoResponseDto?> UpdateAsync(int id, UpdateAbrigoDto dto)
    {
        var abrigo = await _repository.GetByIdWithRelationsAsync(id);
        if (abrigo is null) return null;

        abrigo.Nome = dto.Nome;
        abrigo.Cidade = dto.Cidade;
        abrigo.Estado = dto.Estado.ToUpper();
        abrigo.Endereco = dto.Endereco;
        abrigo.CapacidadeMaxima = dto.CapacidadeMaxima;
        abrigo.Status = dto.Status;

        _repository.Update(abrigo);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(abrigo);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var abrigo = await _repository.GetByIdAsync(id);
        if (abrigo is null) return false;

        _repository.Remove(abrigo);
        await _repository.SaveChangesAsync();
        return true;
    }

    private static AbrigoResponseDto MapToResponseDto(Abrigo abrigo) => new()
    {
        Id = abrigo.Id,
        Nome = abrigo.Nome,
        Cidade = abrigo.Cidade,
        Estado = abrigo.Estado,
        Endereco = abrigo.Endereco,
        CapacidadeMaxima = abrigo.CapacidadeMaxima,
        Status = abrigo.Status.ToString(),
        TotalNecessidades = abrigo.Necessidades?.Count ?? 0,
        TotalDoacoes = abrigo.Doacoes?.Count ?? 0
    };
}
