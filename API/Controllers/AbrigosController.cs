using Microsoft.AspNetCore.Mvc;
using SmartDisaster.Application.DTOs.Abrigo;
using SmartDisaster.Application.Interfaces;

namespace SmartDisaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AbrigosController : ControllerBase
{
    private readonly IAbrigoService _service;

    public AbrigosController(IAbrigoService service)
    {
        _service = service;
    }

    /// <summary>Lista todos os abrigos cadastrados.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AbrigoResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var abrigos = await _service.GetAllAsync();
        return Ok(abrigos);
    }

    /// <summary>Obtém um abrigo pelo ID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AbrigoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var abrigo = await _service.GetByIdAsync(id);
        if (abrigo is null) return NotFound(new { mensagem = $"Abrigo com ID {id} não encontrado." });
        return Ok(abrigo);
    }

    /// <summary>Cadastra um novo abrigo.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(AbrigoResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateAbrigoDto dto)
    {
        var abrigo = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = abrigo.Id }, abrigo);
    }

    /// <summary>Atualiza os dados de um abrigo.</summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(AbrigoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAbrigoDto dto)
    {
        var abrigo = await _service.UpdateAsync(id, dto);
        if (abrigo is null) return NotFound(new { mensagem = $"Abrigo com ID {id} não encontrado." });
        return Ok(abrigo);
    }

    /// <summary>Remove um abrigo. Necessidades e doações vinculadas serão excluídas (cascade).</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _service.DeleteAsync(id);
        if (!removido) return NotFound(new { mensagem = $"Abrigo com ID {id} não encontrado." });
        return NoContent();
    }
}
