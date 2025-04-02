using PizzariaAPI.Models;

namespace PizzariaAPI.Interfaces
{
    public interface IFormaPagamentoService
    {
        Task<IEnumerable<FormaPagamento>> ListarFormasPagamentoAsync();

        Task<FormaPagamento> ObterFormaPagamentoPorIdAsync(int idFormaPagamento);
    }
}
