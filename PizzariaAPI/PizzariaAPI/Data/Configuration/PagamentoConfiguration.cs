using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data.Configuration;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        // Define a tabela no banco de dados
        builder.ToTable("PAGAMENTO");

        // Define a chave primária
        builder.HasKey(p => p.IdPagamento);

        // Configuração da chave estrangeira com Pedido
        builder.HasOne(p => p.Pedido)
               .WithMany() // Um pedido pode ter vários pagamentos
               .HasForeignKey(p => p.IdPedido)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata

        // Configuração do campo Valor
        builder.Property(p => p.Valor)
               .HasColumnType("DECIMAL(10,2)") // Formato decimal
               .IsRequired();

        // Configuração do campo StatusPagamento como enum mapeado para string
        builder.Property(p => p.StatusPagamento)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();
    }
}
