using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
  
        builder.ToTable("pagamento");

        builder.HasKey(p => p.IdPagamento);

        builder.HasOne(p => p.Pedido)
               .WithMany() 
               .HasForeignKey(p => p.IdPedido)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); 

        builder.Property(p => p.Valor)
               .HasColumnType("DECIMAL(10,2)") 
               .IsRequired();

        builder.Property(p => p.StatusPagamento)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();
    }
}
