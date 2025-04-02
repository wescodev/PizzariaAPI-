using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Enums;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<FormaPagamento> FormaPagamento { get; set; }
    public DbSet<Cupom> Cupom { get; set; }
    public DbSet<PedidoItem> PedidoItem { get; set; }
    public DbSet<Endereco> Endereco { get; set; }

}
