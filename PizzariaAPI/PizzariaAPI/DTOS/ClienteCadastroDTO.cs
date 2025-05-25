using PizzariaAPI.Models;

namespace PizzariaAPI.DTOS
{
    public class ClienteCadastroDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string NmEndereco { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }

}
