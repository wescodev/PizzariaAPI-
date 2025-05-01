using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Models; // ou o namespace onde está a classe Pessoa
using System.Threading.Tasks;

namespace PizzariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PessoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pessoas = await _context.Pessoa.ToListAsync();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao acessar o banco de dados: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarPessoaComEndereco([FromBody] Pessoa pessoa)
        {
            try
            {
                // Salva primeiro o endereço (gera IdEndereco)
                _context.Endereco.Add(pessoa.Endereco);
                await _context.SaveChangesAsync();

                // Atribui o IdEndereco gerado à pessoa
                pessoa.IdEndereco = pessoa.Endereco.IdEndereco;

                // Salva a pessoa
                _context.Pessoa.Add(pessoa);
                await _context.SaveChangesAsync();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {ex.Message}");
            }
        }

    }
}
