﻿// <auto-generated />
using System;
using LionDev;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240327015448_UpdateValorToFloat")]
    partial class UpdateValorToFloat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LionDev.Models.Marca", b =>
                {
                    b.Property<Guid>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "LEVI’S"
                        },
                        new
                        {
                            IdMarca = new Guid("07717305-31c4-40b5-958e-072a83e9e45f"),
                            Nombre = "AMAZON ESSENTIALS"
                        },
                        new
                        {
                            IdMarca = new Guid("4254f250-dc80-4097-9015-2faf7fe12659"),
                            Nombre = "JACK & JONES"
                        },
                        new
                        {
                            IdMarca = new Guid("dc06829b-e50b-4ae1-9695-818b3f9aeccd"),
                            Nombre = "KAYHAN"
                        },
                        new
                        {
                            IdMarca = new Guid("fcf5bc09-867d-425a-88e9-b1e476fedb6c"),
                            Nombre = "SPRINGFIELD"
                        },
                        new
                        {
                            IdMarca = new Guid("eaa1e975-861c-4c31-aee9-6c13277d4750"),
                            Nombre = "APOONABA"
                        });
                });

            modelBuilder.Entity("LionDev.Models.Producto", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsDeLosMasBuscados")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdMarca")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParaSexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Talla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdMarca");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            IdProducto = new Guid("0a620f8b-0e2d-4329-a320-8d724cc01bf6"),
                            Cantidad = 100,
                            Color = "Azul",
                            Descripcion = "Camiseta clásica Levi’s",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Camiseta Levi's Original",
                            ParaSexo = "Masculino",
                            Referencia = "CL001",
                            Talla = "M",
                            UrlImagen = "images/levis-camiseta.jpg",
                            Valor = 29.99f
                        },
                        new
                        {
                            IdProducto = new Guid("2aede0fe-501b-450f-94ba-2c57391a9703"),
                            Cantidad = 50,
                            Color = "Negro",
                            Descripcion = "Pantalón cómodo Amazon Essentials",
                            EsDeLosMasBuscados = true,
                            IdMarca = new Guid("07717305-31c4-40b5-958e-072a83e9e45f"),
                            Nombre = "Pantalón Amazon Essentials",
                            ParaSexo = "Femenino",
                            Referencia = "PAE001",
                            Talla = "L",
                            UrlImagen = "images/amazon-essentials-pantalon.jpg",
                            Valor = 45.9f
                        },
                        new
                        {
                            IdProducto = new Guid("33e67a2c-b9d4-4b51-bfca-a434b542fac7"),
                            Cantidad = 70,
                            Color = "Negro",
                            Descripcion = "Chaqueta moderna JACK & JONES en negro",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("4254f250-dc80-4097-9015-2faf7fe12659"),
                            Nombre = "Chaqueta JACK & JONES",
                            ParaSexo = "Masculino",
                            Referencia = "CJJ001",
                            Talla = "L",
                            UrlImagen = "images/jackjones.jpg",
                            Valor = 75f
                        },
                        new
                        {
                            IdProducto = new Guid("862520ce-4ace-4ddd-84a7-301e8beae158"),
                            Cantidad = 60,
                            Color = "Blanco",
                            Descripcion = "Camisa elegante Kayhan en blanco",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("dc06829b-e50b-4ae1-9695-818b3f9aeccd"),
                            Nombre = "Camisa Kayhan Hombre",
                            ParaSexo = "Masculino",
                            Referencia = "CKH001",
                            Talla = "M",
                            UrlImagen = "images/kayhanman.jpg",
                            Valor = 60.99f
                        },
                        new
                        {
                            IdProducto = new Guid("254cf01d-3cfa-4ec4-8088-6ad411579388"),
                            Cantidad = 80,
                            Color = "Verde",
                            Descripcion = "Polo casual SPRINGFIELD en verde",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("fcf5bc09-867d-425a-88e9-b1e476fedb6c"),
                            Nombre = "Polo SPRINGFIELD",
                            ParaSexo = "Masculino",
                            Referencia = "PS001",
                            Talla = "S",
                            UrlImagen = "images/springfield.jpg",
                            Valor = 45.55f
                        },
                        new
                        {
                            IdProducto = new Guid("86096919-9331-4a72-9024-a7b2b08e9be6"),
                            Cantidad = 90,
                            Color = "Gris",
                            Descripcion = "Sudadera APOONABA confortable en gris",
                            EsDeLosMasBuscados = true,
                            IdMarca = new Guid("eaa1e975-861c-4c31-aee9-6c13277d4750"),
                            Nombre = "Sudadera APOONABA",
                            ParaSexo = "Unisex",
                            Referencia = "SA001",
                            Talla = "XL",
                            UrlImagen = "images/apoonaba.jpg",
                            Valor = 65f
                        });
                });

            modelBuilder.Entity("LionDev.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = new Guid("d72a2829-93e9-41f4-9d5f-fed9e32e5df7"),
                            Apellidos = "Falcao",
                            Contrasena = "Rada1",
                            CorreoElectronico = "rada@gmail.com",
                            Nombres = "Radamel",
                            Rol = "Comprador"
                        },
                        new
                        {
                            IdUsuario = new Guid("a49c8a13-35fc-47f4-a7db-3e84cd6ecdea"),
                            Apellidos = "Olivera",
                            Contrasena = "Admin1",
                            CorreoElectronico = "carlos@gmail.com",
                            Nombres = "Carlos",
                            Rol = "Administrador"
                        });
                });

            modelBuilder.Entity("LionDev.Models.Producto", b =>
                {
                    b.HasOne("LionDev.Models.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("LionDev.Models.Marca", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
