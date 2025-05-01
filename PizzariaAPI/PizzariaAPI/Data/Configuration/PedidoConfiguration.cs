using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        // Define a tabela
        builder.ToTable("PEDIDO");

        // Define a chave primária
        builder.HasKey(p => p.IdPedido);

        // Configura a chave estrangeira para Pessoa
        builder.HasOne(p => p.Pessoa)  // Relacionamento com Pessoa
               .WithMany()              // Uma Pessoa pode ter vários Pedidos
               .HasForeignKey(p => p.IdPessoa) // Define a chave estrangeira
               .IsRequired();           // Torna obrigatório
    }
}


