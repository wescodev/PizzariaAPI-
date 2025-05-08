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
        
        builder.HasOne(p => p.Cupom)
            .WithMany()
            .HasForeignKey(p => p.IdCupom)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Endereco)
               .WithMany()
               .HasForeignKey(p => p.IdEndereco)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.FormaPagamento)
               .WithMany()
               .HasForeignKey(p => p.IdFormaPagamento)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
    }
}


