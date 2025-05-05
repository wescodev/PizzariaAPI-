using PizzariaAPI.DTOS;

namespace PizzariaAPI.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTO>> ObterTodosAsync();
        Task<List<ProdutoDTO>> ObterPorCategoriaAsync(int idCategoria);
    }
}
