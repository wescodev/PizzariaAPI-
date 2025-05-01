using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
{
    public void Configure(EntityTypeBuilder<Cupom> builder)
    {
        builder.ToTable("CUPOM");

        builder.HasKey(c => c.IdCupom);

        // Configuração do campo PorcentagemDesconto
        builder.Property(c => c.PorcentagemDesconto)
               .HasColumnType("DECIMAL(5,2)") // Define até 999,99 de desconto
               .IsRequired();

        // Configuração do campo CodigoCupom
        builder.Property(c => c.CodigoCupom)
               .HasColumnType("VARCHAR(50)") // Limite de 50 caracteres para o código do cupom
               .IsRequired();

        // Configuração do campo Status
        builder.Property(c => c.Status)
               .IsRequired();


    }
}


