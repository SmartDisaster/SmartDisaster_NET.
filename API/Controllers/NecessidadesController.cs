using Microsoft.AspNetCore.Mvc;
using SmartDisaster.Application.DTOs.Necessidade;
using SmartDisaster.Application.Interfaces;

namespace SmartDisaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NecessidadesController : ControllerBase
{
    private readonly INecessidadeService _service;

    public NecessidadesController(INecessidadeService service)
    {
        _service = service;
    }

    /// <summary>Lista todas as necessidades registradas nos abrigos.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<NecessidadeResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var necessidades = await _service.GetAllAsync();
        return Ok(necessidades);
    }

    /// <summary>Obtém uma necessidade pelo ID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(NecessidadeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var necessidade = await _service.GetByIdAsync(id);
        if (necessidade is null) return NotFound(new { mensagem = $"Necessidade com ID {id} não encontrada." });
        return Ok(necessidade);
    }

    /// <summary>Registra uma nova necessidade para um abrigo.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(NecessidadeResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateNecessidadeDto dto)
    {
        var necessidade = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = necessidade.Id }, necessidade);
    }

    /// <summary>Atualiza uma necessidade existente.</summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(NecessidadeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateNecessidadeDto dto)
    {
        var necessidade = await _service.UpdateAsync(id, dto);
        if (necessidade is null) return NotFound(new { mensagem = $"Necessidade com ID {id} não encontrada." });
        return Ok(necessidade);
    }

    /// <summary>Remove uma necessidade.</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var removida = await _service.DeleteAsync(id);
        if (!removida) return NotFound(new { mensagem = $"Necessidade com ID {id} não encontrada." });
        return NoContent();
    }
}
