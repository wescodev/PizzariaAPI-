using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Repositories
{
    public class CategoriaProdutoRepository : GenericRepository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(ApplicationDbContext context) : base(context) {  }
        public async Task<IEnumerable<CategoriaProduto>> GetByNomeAsync(string nome)
        {
            return await _dbSet.Where(c => c.NmCategoria.Contains(nome)).ToListAsync();
        }
    }
}
