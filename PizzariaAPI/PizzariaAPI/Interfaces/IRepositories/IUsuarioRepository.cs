using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Interfaces.IRepositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByPessoaIdAsync(int IdPessoa);
        Task AlterarSenhaAsync(int idPessoa, string novaSenha);
    }
}
