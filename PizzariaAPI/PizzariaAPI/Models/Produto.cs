namespace PizzariaAPI.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome{ get; set; }
        public CategoriaProduto IdCategoria { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
