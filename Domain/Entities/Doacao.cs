using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Domain.Entities;

public class Doacao
{
    public int Id { get; set; }
    public string Item { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime DataRegistro { get; set; }
    public StatusDoacao Status { get; set; }
    public int AbrigoId { get; set; }
    public int VoluntarioId { get; set; }

    public Abrigo Abrigo { get; set; } = null!;
    public Voluntario Voluntario { get; set; } = null!;
}
