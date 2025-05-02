using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Models;
using System.Runtime.Intrinsics.X86;

namespace PizzariaAPI.Controllers.CadastroLogin;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClienteController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("CriarCadastroCliente")]
    public async Task<IActionResult> CriarCadastroCliente([FromBody] ClienteCadastroDTO cadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var clienteExiste = await _context.Pessoa.FirstOrDefaultAsync(c => c.CPF == cadastro.CPF);

        if (clienteExiste != null)
        {
            return BadRequest(new { message = "Já existe um cliente cadastrado com esse CPF." });
        }

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            //criar endereco
            var endereco = new Endereco
            {
                NmEndereco = cadastro.NmEndereco,
                CEP = cadastro.CEP,
                Numero = cadastro.Numero,
                Cidade = cadastro.Cidade
            };
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            //criar cliente
            var cliente = new Pessoa
            {
                Nome = cadastro.Nome,
                Email = cadastro.Email,
                CPF = cadastro.CPF,
                Telefone = cadastro.Telefone,
                IdEndereco = endereco.IdEndereco
            };
            _context.Pessoa.Add(cliente);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return Ok(new { message = "Cadastro realizado com sucesso!" });

        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, $"Erro ao criar cadastro: {ex.Message}");
        }
    }

    [HttpPost("CriarUsuarioLogin")]
    public async Task<IActionResult> CriarUsuarioCliente([FromBody] UsuarioCadastroDTO usuario)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pessoa = await _context.Pessoa.FirstOrDefaultAsync(p => p.CPF == usuario.CPF);

        if (pessoa == null)
            return NotFound(new { message = "Pessoa não encontrada para o CPF fornecido." });


        var existeUsuario = await _context.Usuario.FirstOrDefaultAsync(u => u.UsuarioLogin == usuario.UsuarioLogin);

        if (existeUsuario != null)
            return BadRequest(new { message = "Já existe um usuario com este login." });


        var existeCpfVinculo = await _context.Pessoa.FirstOrDefaultAsync(up => up.CPF == usuario.CPF);

        if (existeCpfVinculo != null)
            return BadRequest(new { message = "Já existe um usuario cadastrado para este CPF." });

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            //criar usuario
            var novoUsuario = new Usuario
            {
                UsuarioLogin = usuario.UsuarioLogin,
                Senha = usuario.Senha,
                IdPessoa = pessoa.IdPessoa,
                DataExpiracao = DateTime.Now.AddMonths(1)
            };

            _context.Usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return Ok(new { message = "Login cadastrado com sucesso!" });

        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, $"Erro ao criar login: {ex.Message}");
        }


    }

    //[HttpGet("VerificarCadastroCliente")]
    //public async Task<IActionResult> VerificarCadastroCliente(string cpf)
    //{
    //    var cliente = await _context.Pessoa.Include(p => p.Endereco).FirstOrDefaultAsync(c => c.CPF == cpf);

    //    if (cliente == null)
    //    {
    //        return NotFound(new { message = "Cliente nao encontrado." });
    //    }

    //    return Ok(new
    //    {
    //        idPessoa = cliente.IdPessoa,
    //        nome = cliente.Nome,
    //        email = cliente.Email,
    //        cpf = cliente.CPF,
    //        telefone = cliente.Telefone,
    //        endereco = new
    //        {
    //            idEndereco = cliente.Endereco.IdEndereco,
    //            nmEndereco = cliente.Endereco.NmEndereco,
    //            cep = cliente.Endereco.CEP,
    //            numero = cliente.Endereco.Numero,
    //            cidade = cliente.Endereco.Cidade

    //        }
    //    });

    //}



}
