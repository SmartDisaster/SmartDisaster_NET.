using SmartDisaster.Domain.Enums;

namespace SmartDisaster.Domain.Entities;

public class Abrigo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public int CapacidadeMaxima { get; set; }
    public StatusAbrigo Status { get; set; }

    public ICollection<Necessidade> Necessidades { get; set; } = new List<Necessidade>();
    public ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();
}
