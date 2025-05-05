using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
{
    public void Configure(EntityTypeBuilder<FormaPagamento> builder)
    {
      
        builder.ToTable("forma_pagamento");

       
        builder.HasKey(f => f.IdFormaPagamento);

        builder.Property(f => f.NmFormaPagamento)
               .HasColumnType("VARCHAR(50)") 
               .IsRequired();
    }
}

