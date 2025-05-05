using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;

namespace PizzariaAPI.Controllers.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly ICategoriaProdutoService _categoriaProdutoService;

        public CategoriaProdutoController(ICategoriaProdutoService categoriaProdutoService)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaProdutoDTO>>> ObterCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriaProdutoService.ObterCategoriasAsync();

                if(categorias == null ||  categorias.Count == 0)
                {
                    return NotFound(new { message = "Nenhuma categoria encontrada."});
                }

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao obter categorias: {ex.Message}" });
            }
        }
    }
}
