using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Order");

            builder.HasKey("Id");

            builder.Property(x => x.ClienteId)
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .HasColumnName("ProductId")
                .IsRequired();

            builder.Property(x => x.DataPedido)
                .HasColumnName("Date")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Pedidos);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos);
        }
    }
}
