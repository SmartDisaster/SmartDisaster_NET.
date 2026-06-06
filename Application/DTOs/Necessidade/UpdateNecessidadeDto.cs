using System.ComponentModel.DataAnnotations;
using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Application.DTOs.Necessidade;

public class UpdateNecessidadeDto
{
    [Required(ErrorMessage = "O tipo é obrigatório.")]
    public TipoNecessidade Tipo { get; set; }

    [Required(ErrorMessage = "A quantidade necessária é obrigatória.")]
    [Range(1, 100000, ErrorMessage = "A quantidade deve ser entre 1 e 100.000.")]
    public int QuantidadeNecessaria { get; set; }

    [Required(ErrorMessage = "A prioridade é obrigatória.")]
    public PrioridadeNecessidade Prioridade { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    public StatusNecessidade Status { get; set; }

    [Required(ErrorMessage = "O abrigo é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O AbrigoId deve ser válido.")]
    public int AbrigoId { get; set; }
}
