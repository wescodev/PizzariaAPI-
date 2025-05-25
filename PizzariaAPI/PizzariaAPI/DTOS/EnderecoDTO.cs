namespace PizzariaAPI.DTOS
{
    public class EnderecoDTO
    {
        public string NmEndereco { get; set; } // Nome da Rua/Endereço
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
