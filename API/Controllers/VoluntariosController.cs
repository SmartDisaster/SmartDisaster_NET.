using Microsoft.AspNetCore.Mvc;
using SmartDisaster.Application.DTOs.Voluntario;
using SmartDisaster.Application.Interfaces;

namespace SmartDisaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class VoluntariosController : ControllerBase
{
    private readonly IVoluntarioService _service;

    public VoluntariosController(IVoluntarioService service)
    {
        _service = service;
    }

    /// <summary>Lista todos os voluntários cadastrados.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VoluntarioResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var voluntarios = await _service.GetAllAsync();
        return Ok(voluntarios);
    }

    /// <summary>Obtém um voluntário pelo ID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(VoluntarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var voluntario = await _service.GetByIdAsync(id);
        if (voluntario is null) return NotFound(new { mensagem = $"Voluntário com ID {id} não encontrado." });
        return Ok(voluntario);
    }

    /// <summary>Cadastra um novo voluntário.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(VoluntarioResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateVoluntarioDto dto)
    {
        var voluntario = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = voluntario.Id }, voluntario);
    }

    /// <summary>Atualiza os dados de um voluntário.</summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(VoluntarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVoluntarioDto dto)
    {
        var voluntario = await _service.UpdateAsync(id, dto);
        if (voluntario is null) return NotFound(new { mensagem = $"Voluntário com ID {id} não encontrado." });
        return Ok(voluntario);
    }

    /// <summary>Remove um voluntário.</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _service.DeleteAsync(id);
        if (!removido) return NotFound(new { mensagem = $"Voluntário com ID {id} não encontrado." });
        return NoContent();
    }
}
