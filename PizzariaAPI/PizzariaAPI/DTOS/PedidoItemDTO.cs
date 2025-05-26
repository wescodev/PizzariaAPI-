namespace PizzariaAPI.DTOS
{
    public class PedidoItemDTO
    {

        public int IdProdutoBase { get; set; }

        public string TipoMassa { get; set; }
        public string TipoBorda { get; set; }

        public List<string> ComplementosExtras { get; set; }

        public string Bebida { get; set; }

        public string Observacoes { get; set; }

        public decimal ValorCalculado { get; set; }
    }
}
