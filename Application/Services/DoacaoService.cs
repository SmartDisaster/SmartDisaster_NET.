using SmartDisaster.Application.DTOs.Doacao;
using SmartDisaster.Application.Interfaces;
using SmartDisaster.Domain.Entities;

namespace SmartDisaster.Application.Services;

public class DoacaoService : IDoacaoService
{
    private readonly IDoacaoRepository _repository;

    public DoacaoService(IDoacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DoacaoResponseDto>> GetAllAsync()
    {
        var doacoes = await _repository.GetAllWithRelationsAsync();
        return doacoes.Select(MapToResponseDto);
    }

    public async Task<DoacaoResponseDto?> GetByIdAsync(int id)
    {
        var doacao = await _repository.GetByIdWithRelationsAsync(id);
        return doacao is null ? null : MapToResponseDto(doacao);
    }

    public async Task<DoacaoResponseDto> CreateAsync(CreateDoacaoDto dto)
    {
        var doacao = new Doacao
        {
            Item = dto.Item,
            Quantidade = dto.Quantidade,
            DataRegistro = DateTime.UtcNow,
            Status = dto.Status,
            AbrigoId = dto.AbrigoId,
            VoluntarioId = dto.VoluntarioId
        };

        await _repository.AddAsync(doacao);
        await _repository.SaveChangesAsync();

        var doacaoComRelacoes = await _repository.GetByIdWithRelationsAsync(doacao.Id);
        return MapToResponseDto(doacaoComRelacoes!);
    }

    public async Task<DoacaoResponseDto?> UpdateAsync(int id, UpdateDoacaoDto dto)
    {
        var doacao = await _repository.GetByIdWithRelationsAsync(id);
        if (doacao is null) return null;

        doacao.Item = dto.Item;
        doacao.Quantidade = dto.Quantidade;
        doacao.Status = dto.Status;
        doacao.AbrigoId = dto.AbrigoId;
        doacao.VoluntarioId = dto.VoluntarioId;

        _repository.Update(doacao);
        await _repository.SaveChangesAsync();

        var atualizada = await _repository.GetByIdWithRelationsAsync(id);
        return MapToResponseDto(atualizada!);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doacao = await _repository.GetByIdAsync(id);
        if (doacao is null) return false;

        _repository.Remove(doacao);
        await _repository.SaveChangesAsync();
        return true;
    }

    private static DoacaoResponseDto MapToResponseDto(Doacao d) => new()
    {
        Id = d.Id,
        Item = d.Item,
        Quantidade = d.Quantidade,
        DataRegistro = d.DataRegistro,
        Status = d.Status.ToString(),
        AbrigoId = d.AbrigoId,
        NomeAbrigo = d.Abrigo?.Nome ?? string.Empty,
        VoluntarioId = d.VoluntarioId,
        NomeVoluntario = d.Voluntario?.Nome ?? string.Empty
    };
}
