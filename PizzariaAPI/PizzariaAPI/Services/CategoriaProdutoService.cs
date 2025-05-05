using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Interfaces.Repositories;

namespace PizzariaAPI.Services
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _repository;

        public CategoriaProdutoService(ICategoriaProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaProdutoDTO>> ObterCategoriasAsync()
        {
            var categorias = await _repository.GetAllAsync();
            return categorias.Select(c => new CategoriaProdutoDTO
            {
                NmCategoria = c.NmCategoria ?? string.Empty,
                Descricao = c.Descricao ?? string.Empty,
            }).ToList();
        }

        public Task<List<ProdutoDTO>> ObterPorCategoriaIdAsync(int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
