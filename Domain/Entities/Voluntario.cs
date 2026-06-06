namespace SmartDisaster.Domain.Entities;

public class Voluntario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();
}
