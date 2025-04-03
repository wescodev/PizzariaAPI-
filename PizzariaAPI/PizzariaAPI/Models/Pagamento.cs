using PizzariaAPI.Enums;

namespace PizzariaAPI.Models;

public class Pagamento
{
    public int IdPagamento { get; set; }

    // Chave estrangeira correta
    public int IdPedido { get; set; } // FK

    // Propriedade de navegação
    public Pedido Pedido { get; set; }

    public double Valor { get; set; }
    public EnumPagamento StatusPagamento { get; set; }
}
