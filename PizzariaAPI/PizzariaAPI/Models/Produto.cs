namespace PizzariaAPI.Models;

public class Produto
{
    public int IdProduto { get; set; }
    public string NmProduto { get; set; }

    public int IdCategoria { get; set; } // Chave estrangeira
    public CategoriaProduto Categoria { get; set; } // Relacionamento

    public string Descricao { get; set; }
    public double Valor { get; set; }
}
