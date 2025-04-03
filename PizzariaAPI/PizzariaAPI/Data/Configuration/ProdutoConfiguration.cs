using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("Produto");

        // Define a chave primária
        builder.HasKey(p => p.IdProduto);

        // Define tamanho máximo para strings e obrigatoriedade
        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Descricao)
               .HasMaxLength(255);

        // Configuração da chave estrangeira com CategoriaProduto
        builder.HasOne(p => p.Categoria)
               .WithMany() // Uma categoria pode estar associada a vários produtos
               .HasForeignKey(p => p.IdCategoria)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Evita exclusão acidental da categoria

        // Configuração do campo Valor
        builder.Property(p => p.Valor)
               .IsRequired()
               .HasColumnType("decimal(10,2)"); // Define precisão decimal para valores monetários
    }
}
