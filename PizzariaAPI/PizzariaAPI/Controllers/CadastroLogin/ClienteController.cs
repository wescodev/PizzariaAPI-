using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.DTOS;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Models;
using System.Runtime.Intrinsics.X86;

namespace PizzariaAPI.Controllers.CadastroLogin;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost("CriarCadastroCliente")]
    public async Task<IActionResult> CriarCadastroCliente([FromBody] ClienteCadastroDTO cadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var resultado = await _clienteService.CriarCadastroClienteAsync(cadastro);
            return Ok(new { message = resultado });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }



}
