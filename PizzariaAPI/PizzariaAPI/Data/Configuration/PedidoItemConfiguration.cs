using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            // Define a tabela para a classe PedidoItem
            builder.ToTable("PedidoItem");

            // Define a chave primária da tabela PedidoItem
            builder.HasKey(p => p.IdPedidoItem);

            // Configura a relação entre Pedido e PedidoItem
            builder.HasOne(p => p.IdPedido) // Define o relacionamento com a tabela Pedido
                   .WithMany() // Define que o pedido pode ter muitos PedidosItems
                   .HasForeignKey(p => p.IdPedido) // Define a chave estrangeira
                   .IsRequired(); // Define que a chave estrangeira é obrigatória (não pode ser nula)

            // Configuração para o relacionamento com Produto (assumindo que já tenha a chave estrangeira e a relação)
            builder.HasOne(p => p.IdProduto)
                   .WithMany() // Um pedido tem apenas uma pessoa
                   .HasForeignKey(p => p.IdProduto) // Aqui você ajusta para o id da pessoa, caso tenha
                   .IsRequired();

        }
    }
}
