using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Documento)
                .HasColumnName("Document")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("name")
                .IsRequired();

            builder.HasMany(x => x.Pedidos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId);

            builder.HasData(
                new Cliente(Guid.NewGuid(), "Jhon Doe", "01102203344", "jhon.doe@email.com")
            );
        }

    }
}
