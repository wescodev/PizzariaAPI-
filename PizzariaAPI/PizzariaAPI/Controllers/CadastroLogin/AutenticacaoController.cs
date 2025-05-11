using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Services;

namespace PizzariaAPI.Controllers.CadastroLogin;

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly EmailService _emailService;
    public AutenticacaoController(IPessoaRepository pessoaRepository, IUsuarioRepository usuarioRepository, EmailService emailService)
    {
        _pessoaRepository = pessoaRepository;
        _emailService = emailService;
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pessoa = await _pessoaRepository.GetByEmailOrPhoneAsync(loginDTO.Login);


        if (pessoa == null)
            return Unauthorized(new { message = "Usuário ou senha incorretos" });

        var usuario = await _usuarioRepository.GetByPessoaIdAsync(pessoa.IdPessoa);
   
        if (usuario == null || usuario.Senha != loginDTO.Senha)
            return Unauthorized(new { message = "Usuário ou senha incorretos" });


        return Ok(new { message = "Login bem-sucedido!" });
    }

    [HttpPost("SolicitarAlteracaoSenha")]
    public async Task<IActionResult> SolicitarAlteracaoSenha([FromBody] EmailRequestDTO email)
    {
        var pessoa = await _pessoaRepository.GetByEmailAsync(email.Email);

        if (pessoa == null)
            return NotFound(new { message = "E-mail não encontrado." });

        try
        {
            var mensagem = _emailService.GerarMensagemAlteracaoSenha(pessoa.Nome, pessoa.Email);

            await _emailService.EnviarEmailAsync(pessoa.Email, mensagem);

            return Ok(new { message = "E-mail de solicitação de alteração de senha enviado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Erro ao enviar o e-mail: {ex.Message}" });
        }
    }



    //[HttpGet("RedefinirSenha")]
    //public async Task<IActionResult> RedefinirSenha([FromQuery] string email)
    //{
    //    // Verifica se o e-mail existe no banco
    //    var pessoa = await _pessoaRepository.GetByEmailAsync(email);

    //    if (pessoa == null)
    //        return NotFound(new { message = "E-mail não encontrado ou inválido." });

    //    try
    //    {
    //        var paginaAlterarSenha = $"file:///C:/Users/wesle/Downloads/cs-20250503T030623Z-001/cs/alterarSenha.html?email={email}";

    //        return Redirect(paginaAlterarSenha);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, new { message = $"Erro ao redirecionar: {ex.Message}" });
    //    }
    //}




    [HttpPost("alterarSenha/{email}")]
    public async Task<IActionResult> AlterarSenha(string email, [FromBody] AlterarSenhaRequestDTO request)
    {
        if (request.NovaSenha != request.ConfirmarSenha)
        {
            return BadRequest(new { message = "Nova senha e confirmação de senha não coincidem." });
        }

        try
        {
            var usuario = await _pessoaRepository.GetByEmailAsync(email);

            if(usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            await _usuarioRepository.AlterarSenhaAsync(usuario.IdPessoa, request.NovaSenha);

            return Ok(new { message = "Senha alterada com sucesso." });
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = "Usuário vinculado não encontrado." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Erro ao alterar senha: {ex.Message}" });
        }
    }


}
