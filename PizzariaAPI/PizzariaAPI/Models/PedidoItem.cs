namespace PizzariaAPI.Models
{
    public class PedidoItem
    {
        public int IdPedidoItem { get; set; }
        public Pedido IdPedido { get; set; }
        public Produto IdProduto { get; set; }
    }
}
