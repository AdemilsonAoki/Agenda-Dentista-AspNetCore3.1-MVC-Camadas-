using agenda.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
                      
            builder.Property(c => c.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente);

            builder.HasMany(c => c.Consultas)
                .WithOne(con => con.Cliente)
                .HasForeignKey(con => con.ClienteId);


            builder.ToTable("Clientes");
        }
    }
}
