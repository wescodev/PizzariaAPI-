namespace PizzariaAPI.DTOS;

public class ProdutoDTO
{
    public int IdProduto { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public int IdCategoria { get; set; }
    public string NomeCategoria { get; set; } 
}
