﻿// <auto-generated />
using System;
using CarControl.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarControl.Infrastructure.Migrations
{
    [DbContext(typeof(CarControlContext))]
    [Migration("20230903143854_ATULIAZACAMPOINDEX")]
    partial class ATULIAZACAMPOINDEX
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("CarControl.Domain.Movimento", b =>
                {
                    b.Property<int>("IdMovimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DtEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DtSaida")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("HrEntrada")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("HrSaida")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTpOperacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdVaga")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdMovimento");

                    b.HasIndex("IdTpOperacao");

                    b.HasIndex("IdVaga");

                    b.HasIndex("IdVeiculo");

                    b.ToTable("Movimento");
                });

            modelBuilder.Entity("CarControl.Domain.Operacao", b =>
                {
                    b.Property<int>("IdTpOperacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nmOperacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdTpOperacao");

                    b.ToTable("Operacao");
                });

            modelBuilder.Entity("CarControl.Domain.Vaga", b =>
                {
                    b.Property<int>("IdVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NmVaga")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<char>("flVaga")
                        .HasColumnType("TEXT");

                    b.HasKey("IdVaga");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("CarControl.Domain.Veiculo", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<long>("CpfCondutor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("NmCondutor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlacaVeiculo")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<string>("TpVeiculo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("IdVeiculo");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("CarControl.Domain.Movimento", b =>
                {
                    b.HasOne("CarControl.Domain.Operacao", "TpOperacao")
                        .WithMany("Movimentos")
                        .HasForeignKey("IdTpOperacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarControl.Domain.Vaga", "Vaga")
                        .WithMany("Movimentos")
                        .HasForeignKey("IdTpOperacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarControl.Domain.Veiculo", "Veiculo")
                        .WithMany("Movimentos")
                        .HasForeignKey("IdTpOperacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TpOperacao");

                    b.Navigation("Vaga");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("CarControl.Domain.Operacao", b =>
                {
                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("CarControl.Domain.Vaga", b =>
                {
                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("CarControl.Domain.Veiculo", b =>
                {
                    b.Navigation("Movimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
