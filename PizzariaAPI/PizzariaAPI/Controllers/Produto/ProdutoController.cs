using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;

namespace PizzariaAPI.Controllers.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoDTO>>> ObterTodos()
        {
            try
            {
                var produtos = await _produtoService.ObterTodosAsync();

                if (produtos == null || produtos.Count == 0)
                {
                    return NotFound(new { message = "Nenhum produto encontrado." });
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao obter produtos: {ex.Message}" });
            }
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<ActionResult<List<ProdutoDTO>>> ObterPorCategoria(int idCategoria)
        {
            try
            {
                var produtos = await _produtoService.ObterPorCategoriaAsync(idCategoria);

                if (produtos == null || produtos.Count == 0)
                {
                    return NotFound(new { message = "Nenhum produto encontrado para esta categoria." });
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao obter produtos da categoria: {ex.Message}" });
            }
        }
    }
}
