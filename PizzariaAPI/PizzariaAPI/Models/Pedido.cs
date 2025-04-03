namespace PizzariaAPI.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        // Chave estrangeira
        public int IdPessoa { get; set; }

        // Propriedade de navegação
        public Pessoa Pessoa { get; set; }
    }



}
