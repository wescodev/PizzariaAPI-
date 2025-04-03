namespace PizzariaAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public int IdPessoa { get; set; } // Chave estrangeira
        public Pessoa Pessoa { get; set; } // Relacionamento

        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public DateTime DataExpiracao { get; set; }
    }

}
