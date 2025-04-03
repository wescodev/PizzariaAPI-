namespace PizzariaAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Pessoa IdPessoa { get; set; }
        public string UsuarioLogin { get; set; }
        public Guid Senha { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
