using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("PESSOA");

        // Define a chave primária
        builder.HasKey(p => p.IdPessoa);

        // Define tamanho máximo para strings
        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.CPF)
               .IsRequired()
               .HasMaxLength(11);

        builder.Property(p => p.Telefone)
               .HasMaxLength(20);

        // Configuração da chave estrangeira com Endereco
        builder.HasOne(p => p.Endereco)
               .WithMany() // Um endereço pode estar associado a várias pessoas
               .HasForeignKey(p => p.IdEndereco)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Restrição para evitar exclusão acidental
    }
}

