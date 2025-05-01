using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            // Define a tabela no banco de dados
            builder.ToTable("PEDIDO_ITEM");

            // Define a chave primária
            builder.HasKey(p => p.IdPedidoItem);

            // Configuração da chave estrangeira com Pedido
            builder.HasOne(p => p.Pedido)
                   .WithMany() // Um pedido pode ter vários itens
                   .HasForeignKey(p => p.IdPedido)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata

            // Configuração da chave estrangeira com Produto
            builder.HasOne(p => p.Produto)
                   .WithMany() // Um produto pode estar em vários pedidos
                   .HasForeignKey(p => p.IdProduto)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); // Restrição para evitar exclusão acidental
        }
    }

}
