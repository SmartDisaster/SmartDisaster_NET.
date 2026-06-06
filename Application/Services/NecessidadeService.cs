using SmartDisaster.Application.DTOs.Necessidade;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Services;

public class NecessidadeService : INecessidadeService
{
    private readonly INecessidadeRepository _repository;

    public NecessidadeService(INecessidadeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NecessidadeResponseDto>> GetAllAsync()
    {
        var necessidades = await _repository.GetAllWithRelationsAsync();
        return necessidades.Select(MapToResponseDto);
    }

    public async Task<NecessidadeResponseDto?> GetByIdAsync(int id)
    {
        var necessidade = await _repository.GetByIdWithRelationsAsync(id);
        return necessidade is null ? null : MapToResponseDto(necessidade);
    }

    public async Task<NecessidadeResponseDto> CreateAsync(CreateNecessidadeDto dto)
    {
        var necessidade = new Necessidade
        {
            Tipo = dto.Tipo,
            QuantidadeNecessaria = dto.QuantidadeNecessaria,
            Prioridade = dto.Prioridade,
            Status = dto.Status,
            AbrigoId = dto.AbrigoId
        };

        await _repository.AddAsync(necessidade);
        await _repository.SaveChangesAsync();

        var necessidadeComRelacoes = await _repository.GetByIdWithRelationsAsync(necessidade.Id);
        return MapToResponseDto(necessidadeComRelacoes!);
    }

    public async Task<NecessidadeResponseDto?> UpdateAsync(int id, UpdateNecessidadeDto dto)
    {
        var necessidade = await _repository.GetByIdWithRelationsAsync(id);
        if (necessidade is null) return null;

        necessidade.Tipo = dto.Tipo;
        necessidade.QuantidadeNecessaria = dto.QuantidadeNecessaria;
        necessidade.Prioridade = dto.Prioridade;
        necessidade.Status = dto.Status;
        necessidade.AbrigoId = dto.AbrigoId;

        _repository.Update(necessidade);
        await _repository.SaveChangesAsync();

        var atualizada = await _repository.GetByIdWithRelationsAsync(id);
        return MapToResponseDto(atualizada!);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var necessidade = await _repository.GetByIdAsync(id);
        if (necessidade is null) return false;

        _repository.Remove(necessidade);
        await _repository.SaveChangesAsync();
        return true;
    }

    private static NecessidadeResponseDto MapToResponseDto(Necessidade n) => new()
    {
        Id = n.Id,
        Tipo = n.Tipo.ToString(),
        QuantidadeNecessaria = n.QuantidadeNecessaria,
        Prioridade = n.Prioridade.ToString(),
        Status = n.Status.ToString(),
        AbrigoId = n.AbrigoId,
        NomeAbrigo = n.Abrigo?.Nome ?? string.Empty
    };
}
