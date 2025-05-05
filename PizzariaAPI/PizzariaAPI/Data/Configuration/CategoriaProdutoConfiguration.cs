using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration
{
    public class CategoriaProdutoConfiguration : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            // Define a tabela
            builder.ToTable("categoria_produto");

            builder.HasKey(c => c.IdCategoria);

            builder.Property(c => c.NmCategoria)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Descricao)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
