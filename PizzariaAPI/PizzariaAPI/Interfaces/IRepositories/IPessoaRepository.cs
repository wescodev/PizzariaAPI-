using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Interfaces.IRepositories
{
    public interface IPessoaRepository : IGenericRepository<Pessoa>
    {
        Task<Pessoa> GetByEmailOrPhoneAsync(string login);
        Task<Pessoa> GetByEmailAsync(string email);

    }
}
