namespace PizzariaAPI.DTOS;

public class UsuarioCadastroDTO
{
    public string UsuarioLogin { get; set; }
    public string Senha { get; set; }
    public DateTime DtExpiracao { get; set; }
}
