using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
{
    public void Configure(EntityTypeBuilder<Cupom> builder)
    {
        builder.ToTable("cupom");

        builder.HasKey(c => c.IdCupom);

        builder.Property(c => c.PorcentagemDesconto)
               .HasColumnType("DECIMAL(5,2)") 
               .IsRequired();

        // Configuração do campo CodigoCupom
        builder.Property(c => c.CodigoCupom)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

        // Configuração do campo Status
        builder.Property(c => c.Status)
               .IsRequired();


    }
}


