namespace PizzariaAPI.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Pessoa Pessoa { get; set; }

        public Cupom Cupom { get; set; }
        public Endereco Endereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }


}
