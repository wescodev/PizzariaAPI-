using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {

        builder.ToTable("usuario");


        builder.HasKey(u => u.IdUsuario);

        builder.HasOne(u => u.Pessoa)
               .WithMany() 
               .HasForeignKey(u => u.IdPessoa)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); 

        builder.Property(u => u.UsuarioLogin)
               .IsRequired()
               .HasMaxLength(50);

     
        builder.Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(u => u.DataExpiracao)
               .IsRequired();
    }
}

