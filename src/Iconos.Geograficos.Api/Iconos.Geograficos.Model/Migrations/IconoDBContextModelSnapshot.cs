﻿// <auto-generated />
using System;
using Iconos.Geograficos.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Iconos.Geograficos.Model.Migrations
{
    [DbContext(typeof(IconoDBContext))]
    partial class IconoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.Ciudad", b =>
                {
                    b.Property<int>("IdCiudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadHabitantes")
                        .HasColumnType("int");

                    b.Property<int?>("ContinenteIdContinente")
                        .HasColumnType("int");

                    b.Property<string>("Denominacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdContinente")
                        .HasColumnType("int");

                    b.Property<string>("ImagenThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SuperficieTotal")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("IdCiudad");

                    b.HasIndex("ContinenteIdContinente");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.Continente", b =>
                {
                    b.Property<int>("IdContinente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denominacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContinente");

                    b.ToTable("Continentes");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.IconosReograficos", b =>
                {
                    b.Property<int>("IdIcono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CiudadIdCiudad")
                        .HasColumnType("int");

                    b.Property<string>("Denominacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<string>("ImagenThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIcono");

                    b.HasIndex("CiudadIdCiudad");

                    b.ToTable("Iconos");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.Ciudad", b =>
                {
                    b.HasOne("Iconos.Geograficos.Model.Entities.Continente", "Continente")
                        .WithMany("Ciudades")
                        .HasForeignKey("ContinenteIdContinente");

                    b.Navigation("Continente");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.IconosReograficos", b =>
                {
                    b.HasOne("Iconos.Geograficos.Model.Entities.Ciudad", "Ciudad")
                        .WithMany("IconosGeograficos")
                        .HasForeignKey("CiudadIdCiudad");

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.Ciudad", b =>
                {
                    b.Navigation("IconosGeograficos");
                });

            modelBuilder.Entity("Iconos.Geograficos.Model.Entities.Continente", b =>
                {
                    b.Navigation("Ciudades");
                });
#pragma warning restore 612, 618
        }
    }
}
