namespace PizzariaAPI.DTOS
{
    public class PagamentoDTO
    {
        public string NumeroCartao { get; set; }
        public string NomeTitular { get; set; }
        public int MesValidade { get; set; }
        public int AnoValidade { get; set; }
        public string Cvv { get; set; }
    }
}
