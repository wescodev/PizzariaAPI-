using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;

namespace PizzariaAPI.Controllers.CadastroLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutenticacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.UsuarioLogin == login.Login);

            if (usuario == null || usuario.Senha != login.Senha)
                return Unauthorized(new { message = "Usuário ou senha incorretos" });


            return Ok(new { message = "Login bem-sucedido!" });
        }



        [HttpPut("AtualizarSenha")]
        public async Task<IActionResult> AtualizarSenha([FromBody] AtualizarSenhaDTO usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(p => p.CPF == usuario.CPF);

            var existeUsuario = await _context.Usuario.FirstOrDefaultAsync(u => u.UsuarioLogin == usuario.Usuario);

            if (pessoa == null || existeUsuario == null || existeUsuario.IdPessoa != pessoa.IdPessoa)
                return NotFound(new { message = "Usuario ou CPF não encontrado." });

            try
            {
                existeUsuario.Senha = usuario.Senha;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Senha atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar login: {ex.Message}");
            }

        }
    }
}
