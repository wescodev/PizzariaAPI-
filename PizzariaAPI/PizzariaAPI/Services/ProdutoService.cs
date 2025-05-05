using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;

namespace PizzariaAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProdutoDTO>> ObterPorCategoriaAsync(int idCategoria)
        {
            return await _context.Produto
                .Include(p => p.Categoria) 
                .Where(p => p.IdCategoria == idCategoria) 
                .Select(p => new ProdutoDTO
                {
                    IdProduto = p.IdProduto,  
                    Nome = p.NmProduto,  
                    Descricao = p.Descricao,  
                    Valor = p.Valor,  
                    IdCategoria = p.IdCategoria,  
                    NomeCategoria = p.Categoria.NmCategoria  
                })
                .ToListAsync(); // Executa a consulta e retorna a lista
        }


        public async Task<List<ProdutoDTO>> ObterTodosAsync()
        {
            return await _context.Produto
                .Include(p => p.Categoria)  
                .Select(p => new ProdutoDTO
                {
                    IdProduto = p.IdProduto,  
                    Nome = p.NmProduto,  
                    Descricao = p.Descricao,  
                    Valor = p.Valor,  
                    IdCategoria = p.IdCategoria,  
                    NomeCategoria = p.Categoria.NmCategoria  
                })
                .ToListAsync();  // Executa a consulta e retorna a lista
        }

    }
}
