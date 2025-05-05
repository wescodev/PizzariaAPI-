using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
       
        builder.ToTable("pessoa");

       
        builder.HasKey(p => p.IdPessoa);

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

        builder.HasOne(p => p.Endereco)
               .WithMany() 
               .HasForeignKey(p => p.IdEndereco)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); 
    }
}

