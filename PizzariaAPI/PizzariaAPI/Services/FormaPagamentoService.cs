using PizzariaAPI.Data;
using PizzariaAPI.Interfaces; // Certifique-se de que este using esteja aquiusing PizzariaAPI.Models;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Services
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly ApplicationDbContext _context;

        public FormaPagamentoService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context), "O contexto de dados não pode ser nulo.");
        }

        public async Task<IEnumerable<FormaPagamento>> ListarFormasPagamentoAsync()
            => await _context.FormaPagamento.ToListAsync();

        public async Task<FormaPagamento> ObterFormaPagamentoPorIdAsync(int idFormaPagamento)
            => await _context.FormaPagamento.FirstOrDefaultAsync(fp => fp.IdFormaPagamento == idFormaPagamento);
    }
}
