using System;
using System.Collections.Generic;
using System.Text;
using agenda.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda.Data.Mappings
{
    public class DentistaMapping : IEntityTypeConfiguration<Dentista>
    {
        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(d => d.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(d => d.Documento)
              .IsRequired()
              .HasColumnType("varchar(14)");

            builder.HasMany(d => d.Consultas)
                .WithOne(con => con.Dentista)
                .HasForeignKey(con => con.DentistaId);


            builder.ToTable("Dentistas");
        }
    }   
}
