namespace PizzariaAPI.Models
{
    public class Cupom
    {
        public int IdCupom { get; set; }
        public decimal PorcentagemDesconto { get; set; }
        public string CodigoCupom { get; set; }
        public bool Status{ get; set; }
    }
}
