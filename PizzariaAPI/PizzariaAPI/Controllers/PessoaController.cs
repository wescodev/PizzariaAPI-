using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;

namespace PizzariaAPI.Controllers;

[ApiController]
[Route("api[controller]")]
public class PessoaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PessoaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var pessoas = await _context.Pessoa.ToListAsync();
        return Ok(pessoas);
    }
}
