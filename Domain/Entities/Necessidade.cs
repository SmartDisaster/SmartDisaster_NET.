using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Domain.Entities;

public class Necessidade
{
    public int Id { get; set; }
    public TipoNecessidade Tipo { get; set; }
    public int QuantidadeNecessaria { get; set; }
    public PrioridadeNecessidade Prioridade { get; set; }
    public StatusNecessidade Status { get; set; }
    public int AbrigoId { get; set; }

    public Abrigo Abrigo { get; set; } = null!;
}
