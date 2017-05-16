using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FN.CadRestaurante.Infra.Data.EF;

namespace FN.CadRestaurante.Infra.Data.Migrations
{
    [DbContext(typeof(CadRestauranteDataContext))]
    [Migration("20170516183243_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FN.CadRestaurante.Domain.Entities.Prato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnName("Preco")
                        .HasColumnType("money");

                    b.Property<Guid>("RestauranteId");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("FN.CadRestaurante.Domain.Entities.Restaurante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("FN.CadRestaurante.Domain.Entities.Prato", b =>
                {
                    b.HasOne("FN.CadRestaurante.Domain.Entities.Restaurante", "Restaurante")
                        .WithMany("Pratos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
