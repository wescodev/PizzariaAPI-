namespace PizzariaAPI.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public int IdCupom { get; set; }
        public Cupom Cupom { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public int IdFormaPagamento { get; set; }
        public FormaPagamento FormaPagamento { get; set; }


    }



}
