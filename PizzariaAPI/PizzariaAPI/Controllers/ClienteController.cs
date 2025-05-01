using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Models;

namespace PizzariaAPI.Controllers;

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
      if(!ModelState.IsValid)
          return BadRequest(ModelState);

      var clienteExiste = await _context.Pessoa.FirstOrDefaultAsync(c => c.CPF == cadastro.CPF);

      if(clienteExiste != null)
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

    [HttpGet("VerificarCadastroCliente")]
    public async Task<IActionResult> VerificarCadastroCliente(string cpf)
    {
        var cliente = await _context.Pessoa.FirstOrDefaultAsync(c => c.CPF == cpf);

        if (cliente == null)
        {
            return NotFound(new { message = "Cliente nao encontrado." });
        }

        return Ok(new
        {
            cliente.Nome,
            cliente.Email,
            cliente.CPF,
            cliente.Telefone,
            cliente.IdEndereco

        });

    }
    //criar usuario
    //var usuario = new Usuario
    //{
    //    IdPessoa = cliente.IdPessoa,
    //    UsuarioLogin = cadastro.Login,
    //    Senha = cadastro.Senha,
    //    DataExpiracao = DateTime.Now.AddMonths(1)
    //};
    //_context.Usuario.Add(usuario);
    //        await _context.SaveChangesAsync();


}
