using PizzariaAPI.DTOS;

namespace PizzariaAPI.Interfaces
{
    public interface ICategoriaProdutoService
    {
        Task<List<CategoriaProdutoDTO>> ObterCategoriasAsync();
    }
}
