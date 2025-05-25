using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Models;

namespace PizzariaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPessoaRepository _pessoaRepository;

        public ClienteService(ApplicationDbContext context, IPessoaRepository pessoaRepository)
        {
            _context = context;
            _pessoaRepository = pessoaRepository;
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
                Estado = cadastro.Estado,
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
                DataExpiracao = DateTime.UtcNow.AddMonths(1)
            };
            _context.Usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return "Login cadastrado com sucesso!";
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
                Console.WriteLine($"Erro ao criar cadastro de cliente: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    if (ex.InnerException is Npgsql.PostgresException pgEx)
                    {
                        Console.WriteLine($"PostgreSQL Error Code: {pgEx.SqlState}");
                        Console.WriteLine($"PostgreSQL Detail: {pgEx.Detail}");
                        Console.WriteLine($"PostgreSQL Constraint: {pgEx.ConstraintName}");
                    }
                }
                throw; // repassa o erro para o Controller
            }
    
        }

       public async Task<string> ObterEnderecoFormatadoDoClienteAsync(int idCliente)
        {
            // Usa o repositório para buscar a Pessoa com o Endereco
            var pessoa = await _pessoaRepository.ObterPessoaComEnderecoPorIdAsync(idCliente);

            if (pessoa == null || pessoa.Endereco == null)
            {
                throw new Exception("Cliente ou endereço não encontrado.");
            }

            var endereco = pessoa.Endereco;
            return $"{endereco.NmEndereco}, {endereco.Cidade}, {endereco.Estado ?? "N/A"}, {endereco.CEP}";
        }
    }
}
