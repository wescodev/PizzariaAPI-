namespace PizzariaAPI.Models
{
    public class PedidoItem
    {
        public int IdPedidoItem { get; set; }

        // Chaves estrangeiras
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        // Propriedades de navegação
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }

}
