namespace PizzariaAPI.DTOS
{
    public class CriarPedidoDTO
    {
        public int Idcliente { get; set; }
        public int IdEndereco { get; set; }
        public PedidoItemDTO ItemPedido { get; set; }
        public PagamentoDTO DadosPagamento { get; set; }
    }
}
