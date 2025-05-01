using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("ENDERECO");

        // Define a chave primária
        builder.HasKey(e => e.IdEndereco);

        // Configuração do campo NomeEndereco
        builder.Property(e => e.NmEndereco)
               .HasColumnType("VARCHAR(100)") // Limite de 100 caracteres
               .IsRequired();

        // Configuração do campo CEP
        builder.Property(e => e.CEP)
               .HasColumnType("VARCHAR(9)") // Formato 00000-000
               .IsRequired();

        // Configuração do campo Numero
        builder.Property(e => e.Numero)
               .IsRequired();

        // Configuração do campo Cidade
        builder.Property(e => e.Cidade)
               .HasColumnType("VARCHAR(50)") // Limite de 50 caracteres
               .IsRequired();

        //// Configuração do campo Estado
        //builder.Property(e => e.Estado)
        //       .HasColumnType("VARCHAR(2)") // Padrão de siglas (SP, RJ, etc.)
        //       .IsRequired();
    }
}
