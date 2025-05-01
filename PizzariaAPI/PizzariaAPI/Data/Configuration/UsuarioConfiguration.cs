using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("USUARIO");

        // Define a chave primária
        builder.HasKey(u => u.IdUsuario);

        // Configuração do relacionamento com Pessoa
        builder.HasOne(u => u.Pessoa)
               .WithMany() // Uma pessoa pode estar associada a vários usuários? Se não, troque para WithOne()
               .HasForeignKey(u => u.IdPessoa)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Evita exclusão acidental da Pessoa

        // Define restrições para o nome de usuário
        builder.Property(u => u.UsuarioLogin)
               .IsRequired()
               .HasMaxLength(50);

        // Define restrições para a senha
        builder.Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(255); // Tamanho ideal para armazenamento seguro (hash)

        // Define a data de expiração como obrigatória
        builder.Property(u => u.DataExpiracao)
               .IsRequired();
    }
}

