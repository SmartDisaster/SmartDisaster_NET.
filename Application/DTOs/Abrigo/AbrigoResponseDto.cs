using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Application.DTOs.Abrigo;

public class AbrigoResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public int CapacidadeMaxima { get; set; }
    public string Status { get; set; } = string.Empty;
    public int TotalNecessidades { get; set; }
    public int TotalDoacoes { get; set; }
}
