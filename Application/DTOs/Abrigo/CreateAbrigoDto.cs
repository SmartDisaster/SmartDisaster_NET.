using System.ComponentModel.DataAnnotations;
using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Application.DTOs.Abrigo;

public class CreateAbrigoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter exatamente 2 caracteres (ex: SP).")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
    [Range(1, 10000, ErrorMessage = "A capacidade deve ser entre 1 e 10.000 pessoas.")]
    public int CapacidadeMaxima { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    public StatusAbrigo Status { get; set; }
}
