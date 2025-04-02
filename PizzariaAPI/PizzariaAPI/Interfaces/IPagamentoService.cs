using PizzariaAPI.Models;

namespace PizzariaAPI.Interfaces
{
    public interface IPagamentoService
    {
        Task<bool> ProcessarPagamentoAsync(Pedido pedido, decimal valor, string pagamentoDetalhes);
    }
}
