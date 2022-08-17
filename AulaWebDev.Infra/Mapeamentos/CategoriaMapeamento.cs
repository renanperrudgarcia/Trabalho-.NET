using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Descricao)
                .HasColumnName("Description")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Codigo)
                .HasColumnName("Code")
                .IsRequired();

            builder.HasMany(c => c.Produtos)
              .WithOne(c => c.Categoria)
              .HasForeignKey(c => c.CategoriaId);
        }

    }
}
