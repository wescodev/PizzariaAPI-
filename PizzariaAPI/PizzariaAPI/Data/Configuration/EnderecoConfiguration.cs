using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("endereco");

        builder.HasKey(e => e.IdEndereco);

        builder.Property(e => e.NmEndereco)
               .HasColumnType("VARCHAR(100)") 
               .IsRequired();

        builder.Property(e => e.CEP)
               .HasColumnType("VARCHAR(9)") 
               .IsRequired();

        builder.Property(e => e.Estado)
                .HasColumnType("VARCHAR(2)")
               .IsRequired();

        builder.Property(e => e.Cidade)
               .HasColumnType("VARCHAR(50)") 
               .IsRequired();

    }
}
