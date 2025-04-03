using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
{
    public void Configure(EntityTypeBuilder<FormaPagamento> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("FormaPagamento");

        // Define a chave primária
        builder.HasKey(f => f.IdFormaPagamento);

        // Configuração do campo NomeFormaPagamento
        builder.Property(f => f.NmFormaPagamento)
               .HasColumnType("VARCHAR(50)") // Limite de 50 caracteres
               .IsRequired();
    }
}

