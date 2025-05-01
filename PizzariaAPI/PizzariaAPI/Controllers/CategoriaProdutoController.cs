using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            try
            {
                var categoria = await _context.CategoriaProduto.ToListAsync();
                return Ok(categoria);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Erro ao acessar o banco de dados: {ex.Message}");
            }
        }
    }
}
