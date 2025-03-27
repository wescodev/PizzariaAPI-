using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.IdPedido);

            builder.HasOne(p => p.FormaPagamento)
                .WithMany()
                .HasForeignKey(p => p.FormaPagamentoId)
                .IsRequired();

            builder.HasOne(p => p.Pessoa)
                  .WithMany()
                  .HasForeignKey(p => p.Pessoa);

            builder.HasOne(p => p.Cupom)
                .WithMany()
                .HasForeignKey(p => p.Cupom)
                .IsRequired();

            builder.HasOne(p => p.Endereco)
            .WithMany()
            .HasForeignKey(p => p.Endereco)
            .IsRequired();

  


        }
    }
}
