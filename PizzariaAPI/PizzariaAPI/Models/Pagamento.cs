using PizzariaAPI.Enums;

namespace PizzariaAPI.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public Pedido IdPedido{ get; set; }
        public double Valor { get; set; }
        public EnumPagamento StatusPagamento { get; set; }

    }
}
