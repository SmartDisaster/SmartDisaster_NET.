namespace SmartDisaster.Application.DTOs.Necessidade;

public class NecessidadeResponseDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int QuantidadeNecessaria { get; set; }
    public string Prioridade { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int AbrigoId { get; set; }
    public string NomeAbrigo { get; set; } = string.Empty;
}
