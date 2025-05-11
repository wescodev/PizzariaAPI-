using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context) { }
        public async Task AlterarSenhaAsync(int IdPessoa, string novaSenha)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.IdPessoa == IdPessoa);
            if(usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            usuario.Senha = novaSenha;

            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }


        public async Task<Usuario> GetByPessoaIdAsync(int IdPessoa)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.IdPessoa == IdPessoa);

            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            return usuario;
        }
    }
}
