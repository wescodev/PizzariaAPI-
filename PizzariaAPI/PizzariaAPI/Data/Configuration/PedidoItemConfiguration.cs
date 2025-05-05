using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {

            builder.ToTable("pedido_item");

            builder.HasKey(p => p.IdPedidoItem);

            builder.HasOne(p => p.Pedido)
                   .WithMany() 
                   .HasForeignKey(p => p.IdPedido)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(p => p.Produto)
                   .WithMany() 
                   .HasForeignKey(p => p.IdProduto)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }

}
