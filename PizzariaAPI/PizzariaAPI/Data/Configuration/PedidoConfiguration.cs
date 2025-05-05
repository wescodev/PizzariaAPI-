using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("pedido");


        builder.HasKey(p => p.IdPedido);

        builder.HasOne(p => p.Pessoa)  
               .WithMany()              
               .HasForeignKey(p => p.IdPessoa) 
               .IsRequired();           
    }
}


