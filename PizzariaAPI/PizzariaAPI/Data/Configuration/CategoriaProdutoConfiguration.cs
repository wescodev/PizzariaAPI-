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
            builder.ToTable("CATEGORIA_PRODUTO");

            builder.HasKey(c => c.IdCategoria);


            // Define o nome da categoria como obrigatório e com tamanho máximo
            builder.Property(c => c.NmCategoria)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
