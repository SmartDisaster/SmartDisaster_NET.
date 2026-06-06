namespace SmartDisaster.Application.DTOs.Doacao;

public class DoacaoResponseDto
{
    public int Id { get; set; }
    public string Item { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime DataRegistro { get; set; }
    public string Status { get; set; } = string.Empty;
    public int AbrigoId { get; set; }
    public string NomeAbrigo { get; set; } = string.Empty;
    public int VoluntarioId { get; set; }
    public string NomeVoluntario { get; set; } = string.Empty;
}
