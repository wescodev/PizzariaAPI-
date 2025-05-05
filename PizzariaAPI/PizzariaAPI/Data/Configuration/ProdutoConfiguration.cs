using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {

        builder.ToTable("produto");

        builder.HasKey(p => p.IdProduto);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Descricao)
               .HasMaxLength(255);

        builder.HasOne(p => p.Categoria)
               .WithMany() 
               .HasForeignKey(p => p.IdCategoria)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Valor)
               .IsRequired()
               .HasColumnType("decimal(10,2)"); 
    }
}
