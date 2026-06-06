using Microsoft.AspNetCore.Mvc;
using SmartDisaster.Application.DTOs.Doacao;
using SmartDisaster.Application.Interfaces;

namespace SmartDisaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class DoacoesController : ControllerBase
{
    private readonly IDoacaoService _service;

    public DoacoesController(IDoacaoService service)
    {
        _service = service;
    }

    /// <summary>Lista todas as doações registradas.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DoacaoResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var doacoes = await _service.GetAllAsync();
        return Ok(doacoes);
    }

    /// <summary>Obtém uma doação pelo ID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(DoacaoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var doacao = await _service.GetByIdAsync(id);
        if (doacao is null) return NotFound(new { mensagem = $"Doação com ID {id} não encontrada." });
        return Ok(doacao);
    }

    /// <summary>Registra uma nova doação vinculada a um abrigo e voluntário.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(DoacaoResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateDoacaoDto dto)
    {
        var doacao = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = doacao.Id }, doacao);
    }

    /// <summary>Atualiza os dados de uma doação.</summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(DoacaoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDoacaoDto dto)
    {
        var doacao = await _service.UpdateAsync(id, dto);
        if (doacao is null) return NotFound(new { mensagem = $"Doação com ID {id} não encontrada." });
        return Ok(doacao);
    }

    /// <summary>Remove uma doação.</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var removida = await _service.DeleteAsync(id);
        if (!removida) return NotFound(new { mensagem = $"Doação com ID {id} não encontrada." });
        return NoContent();
    }
}
