namespace PizzariaAPI.Models;

public class Pessoa
{
    public int IdPessoa { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public int IdEndereco { get; set; } // Chave estrangeira
    public Endereco Endereco { get; set; } // Relacionamento
}
