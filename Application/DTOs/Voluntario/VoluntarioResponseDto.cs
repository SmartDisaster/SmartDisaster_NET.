namespace SmartDisaster.Application.DTOs.Voluntario;

public class VoluntarioResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public int TotalDoacoes { get; set; }
}
