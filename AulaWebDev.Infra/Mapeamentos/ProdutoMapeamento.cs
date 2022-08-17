using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Descricao)
                .HasColumnName("Description")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Codigo)
                .HasColumnName("Code")
                .IsRequired();

            builder.Property(x => x.CategoriaId)
               .HasColumnName("CategoriaId")
               .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnName("Price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(c => c.QuantidadeEstoque)
                .HasColumnName("Stock")
                .IsRequired();

            builder.HasMany(c => c.Pedidos)
                .WithOne(c => c.Produto)
                .HasForeignKey(c => c.ProdutoId);

            builder.HasOne(x => x.Categoria)
               .WithMany(x => x.Produtos);
        }

    }
}
