using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Models;

namespace PizzariaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CriarCadastroClienteAsync(ClienteCadastroDTO cadastro)
        {
            if (cadastro.Senha != cadastro.ConfirmarSenha)
                throw new Exception("As senhas não coincidem");

            var cpfExiste = await _context.Pessoa.FirstOrDefaultAsync(c => c.CPF == cadastro.CPF);

            if (cpfExiste != null)
                throw new Exception("Já existe um cliente cadastrado com esse CPF.");

            var emailExiste = await _context.Pessoa.FirstOrDefaultAsync(c => c.Email == cadastro.Email);
            if (emailExiste != null)
                throw new Exception("Já existe um cliente cadastrado com esse Email.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var endereco = new Endereco
                {
                    NmEndereco = cadastro.NmEndereco,
                    CEP = cadastro.CEP,
                    Numero = cadastro.Numero,
                    Cidade = cadastro.Cidade
                };
                _context.Endereco.Add(endereco);
                await _context.SaveChangesAsync();

                var pessoa = new Pessoa
                {
                    Nome = cadastro.Nome,
                    Email = cadastro.Email,
                    CPF = cadastro.CPF,
                    Telefone = cadastro.Telefone,
                    IdEndereco = endereco.IdEndereco
                };
                _context.Pessoa.Add(pessoa);
                await _context.SaveChangesAsync();

                var novoUsuario = new Usuario
                {
                    IdPessoa = pessoa.IdPessoa,
                    UsuarioLogin = pessoa.Email,
                    Senha = cadastro.Senha,
                    DataExpiracao = DateTime.Now.AddMonths(1)
                };
                _context.Usuario.Add(novoUsuario);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return "Login cadastrado com sucesso!";
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; 
            }
        }
    }
    }
}
