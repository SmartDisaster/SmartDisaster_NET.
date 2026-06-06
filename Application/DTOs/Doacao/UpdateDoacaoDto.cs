using System.ComponentModel.DataAnnotations;
using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Application.DTOs.Doacao;

public class UpdateDoacaoDto
{
    [Required(ErrorMessage = "O item é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O item deve ter entre 2 e 100 caracteres.")]
    public string Item { get; set; } = string.Empty;

    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, 100000, ErrorMessage = "A quantidade deve ser entre 1 e 100.000.")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    public StatusDoacao Status { get; set; }

    [Required(ErrorMessage = "O abrigo é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O AbrigoId deve ser válido.")]
    public int AbrigoId { get; set; }

    [Required(ErrorMessage = "O voluntário é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O VoluntarioId deve ser válido.")]
    public int VoluntarioId { get; set; }
}
