using PizzariaAPI.Models;

namespace PizzariaAPI.Interfaces.Repositories
{
    public interface ICategoriaProdutoRepository : IGenericRepository<CategoriaProduto>
    {
        Task<IEnumerable<CategoriaProduto>> GetByNomeAsync(string nome);
    }
}
