﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using agenda.Data.Context;

namespace agenda.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("agenda.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("agenda.Business.Models.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DentistaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DentistaId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("agenda.Business.Models.Dentista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Dentistas");
                });

            modelBuilder.Entity("agenda.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("agenda.Business.Models.Consulta", b =>
                {
                    b.HasOne("agenda.Business.Models.Cliente", "Cliente")
                        .WithMany("Consultas")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("agenda.Business.Models.Dentista", "Dentista")
                        .WithMany("Consultas")
                        .HasForeignKey("DentistaId")
                        .IsRequired();
                });

            modelBuilder.Entity("agenda.Business.Models.Endereco", b =>
                {
                    b.HasOne("agenda.Business.Models.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("agenda.Business.Models.Endereco", "ClienteId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}