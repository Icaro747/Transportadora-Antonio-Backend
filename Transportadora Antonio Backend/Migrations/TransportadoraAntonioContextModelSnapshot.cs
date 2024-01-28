﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transportadora_Antonio_Backend.Data;

#nullable disable

namespace Transportadora_Antonio_Backend.Migrations
{
    [DbContext(typeof(TransportadoraAntonioContext))]
    partial class TransportadoraAntonioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.EventoVeiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDespesa")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("EventoVeiculos");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.RelacaoFuncionárioVeiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("RelacaoFuncionarioVeiculo", (string)null);
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModificadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.EventoVeiculo", b =>
                {
                    b.HasOne("Transportadora_Antonio_Backend.Enities.Categoria", "Categoria")
                        .WithMany("EventoVeiculos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transportadora_Antonio_Backend.Enities.Veiculo", "Veiculo")
                        .WithMany("EventosVeiculo")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.RelacaoFuncionárioVeiculo", b =>
                {
                    b.HasOne("Transportadora_Antonio_Backend.Enities.Funcionario", "Funcionario")
                        .WithMany("RelacaoFuncionárioVeiculo")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transportadora_Antonio_Backend.Enities.Veiculo", "Veiculo")
                        .WithMany("RelacaoFuncionárioVeiculo")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Categoria", b =>
                {
                    b.Navigation("EventoVeiculos");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Funcionario", b =>
                {
                    b.Navigation("RelacaoFuncionárioVeiculo");
                });

            modelBuilder.Entity("Transportadora_Antonio_Backend.Enities.Veiculo", b =>
                {
                    b.Navigation("EventosVeiculo");

                    b.Navigation("RelacaoFuncionárioVeiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
