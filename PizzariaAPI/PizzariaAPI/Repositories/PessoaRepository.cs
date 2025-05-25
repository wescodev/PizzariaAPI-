using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Repositories
{
    public class PessoaRepository : GenericRepository<Pessoa>, IPessoaRepository
    {

        public PessoaRepository(ApplicationDbContext context) : base(context) { }
  
        public Task<Pessoa> GetByEmailAsync(string email)
        {
            return _dbSet.FirstOrDefaultAsync(p => p.Email == email);
        }

        public Task<Pessoa> GetByEmailOrPhoneAsync(string login)
        {
            return _dbSet.FirstOrDefaultAsync(p => p.Email == login || p.Telefone == login);
        }

        public Task<Pessoa> ObterPessoaComEnderecoPorIdAsync(int idPessoa)
        {
            return _dbSet.Include(p => p.Endereco).FirstOrDefaultAsync(p => p.IdPessoa == idPessoa);
        }
    }
}
