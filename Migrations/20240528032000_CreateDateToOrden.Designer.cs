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
    [Migration("20240528032000_CreateDateToOrden")]
    partial class CreateDateToOrden
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LionDev.Models.Color", b =>
                {
                    b.Property<Guid>("IdColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdColor");

                    b.ToTable("Colores");
                });

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
                            Nombre = "FASHION NOVA X"
                        });
                });

            modelBuilder.Entity("LionDev.Models.Orden", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DeliveryInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrdenId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("LionDev.Models.OrdenItem", b =>
                {
                    b.Property<int>("OrdenItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenItemId"));

                    b.Property<int?>("OrdenId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrdenItemId");

                    b.HasIndex("OrdenId");

                    b.ToTable("OrdenItem");
                });

            modelBuilder.Entity("LionDev.Models.PendingUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PendingUsuarios");
                });

            modelBuilder.Entity("LionDev.Models.Producto", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdMarca");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            IdProducto = new Guid("2d98ccdb-9393-4d36-998b-7b1ad994e8e0"),
                            Cantidad = 100,
                            Color = "Negro",
                            Descripcion = "Distintiva y elegante, esta camisa de vestir negra cuenta con un diseño de rayas sutiles que le añade textura y profundidad. Las rayas finas complementan el color negro, mientras que el corte y estilo clásicos aseguran versatilidad para cualquier ocasión formal.",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Camisa de vestir negra con rayas sutiles",
                            ParaSexo = "Masculino",
                            Referencia = "CL001",
                            Talla = "M",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpj0mjV27AORratnF?e=fqKpgO",
                            Valor = 25
                        },
                        new
                        {
                            IdProducto = new Guid("17e15c41-cec7-4ed6-a393-d7e0198e93d1"),
                            Cantidad = 50,
                            Color = "Negro",
                            Descripcion = "Esta camisa negra para mujer combina comodidad y estilo con su corte relajado y femenino. El tejido suave y fluido asegura una caída elegante, ideal para un atuendo chic y cómodo. El color negro profundo proporciona una base versátil y sofisticada para diversos looks.",
                            EsDeLosMasBuscados = true,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Camisa casual negra para mujer",
                            ParaSexo = "Femenino",
                            Referencia = "PAE001",
                            Talla = "L",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkCS4J54_owfge8W?e=E5cCWw",
                            Valor = 30
                        },
                        new
                        {
                            IdProducto = new Guid("fba5415e-7d4b-42c7-8507-6665aaf257f5"),
                            Cantidad = 70,
                            Color = "Verde",
                            Descripcion = "Esta camisa de denim para mujer en un tono verde terroso combina estilo y practicidad. Con un diseño entallado, cuello definido, botones frontales y bolsillos en el pecho, ofrece una mezcla perfecta de moda y funcionalidad. El tejido de denim duradero y el color verde rico proporcionan un look contemporáneo y chic.",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Camisa de denim verde para mujer",
                            ParaSexo = "Femenino",
                            Referencia = "CJJ001",
                            Talla = "L",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi4bbUEdiChClAsk?e=J0gbK1",
                            Valor = 34
                        },
                        new
                        {
                            IdProducto = new Guid("26f32682-a2d8-4388-82ce-c4bf421317ad"),
                            Cantidad = 60,
                            Color = "Azul",
                            Descripcion = "Representando la esencia del vestuario masculino, esta camisa de denim azul ofrece un ajuste clásico con cuello resistente, botones frontales y bolsillos en el pecho. El color azul profundo y el tejido de denim robusto la convierten en una opción durable y siempre en estilo para el hombre moderno.",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Camisa de denim azul para hombre",
                            ParaSexo = "Masculino",
                            Referencia = "CKH001",
                            Talla = "M",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpjSYxXw65EDf-FH_?e=gsaGkp",
                            Valor = 36
                        },
                        new
                        {
                            IdProducto = new Guid("52e996d1-cc5f-4552-a74c-48257860c171"),
                            Cantidad = 80,
                            Color = "Azul",
                            Descripcion = "Esta camisa polo azul para hombre destaca por su tejido piqué suave y transpirable, ofreciendo un ajuste clásico con cuello y placa de botones. El color azul profundo y el diseño elegante la hacen perfecta para ocasiones casuales o semi-formales, reflejando un estilo deportivo y refinado.",
                            EsDeLosMasBuscados = false,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Polo azul para hombre",
                            ParaSexo = "Masculino",
                            Referencia = "PS001",
                            Talla = "S",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi9NCvaItrYntnUW?e=3mn8YK",
                            Valor = 45
                        },
                        new
                        {
                            IdProducto = new Guid("aa19593d-55f6-4380-a73a-1c48168d0b8d"),
                            Cantidad = 90,
                            Color = "Verde",
                            Descripcion = "Esta camisa polo para mujer en un tono verde vibrante cuenta con un ajuste a medida, cuello elegante y placa de botones. Fabricada en tejido piqué suave y transpirable, combina elegancia con funcionalidad, ideal para llevar en actividades activas o como parte de un atuendo casual elegante.",
                            EsDeLosMasBuscados = true,
                            IdMarca = new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"),
                            Nombre = "Polo verde para mujer",
                            ParaSexo = "Femenino",
                            Referencia = "SA001",
                            Talla = "XL",
                            UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkL_drp6tX5BfRmN?e=GDLN5j",
                            Valor = 43
                        });
                });

            modelBuilder.Entity("LionDev.Models.ProductoColor", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorIdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductoIdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProducto", "IdColor");

                    b.HasIndex("ColorIdColor");

                    b.HasIndex("ProductoIdProducto");

                    b.ToTable("ProductoColores");
                });

            modelBuilder.Entity("LionDev.Models.ProductoTalla", b =>
                {
                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTalla")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductoIdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TallaIdTalla")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProducto", "IdTalla");

                    b.HasIndex("ProductoIdProducto");

                    b.HasIndex("TallaIdTalla");

                    b.ToTable("ProductoTallas");
                });

            modelBuilder.Entity("LionDev.Models.Talla", b =>
                {
                    b.Property<Guid>("IdTalla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTalla");

                    b.ToTable("Tallas");
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

                    b.Property<string>("ConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

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
                            IdUsuario = new Guid("9b380e62-52f2-4fe6-a0fc-99664828f3af"),
                            Apellidos = "Falcao",
                            Contrasena = "Rada1",
                            CorreoElectronico = "rada@gmail.com",
                            EmailConfirmado = false,
                            FechaRegistro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = 0,
                            Nombres = "Radamel",
                            Rol = "Comprador"
                        },
                        new
                        {
                            IdUsuario = new Guid("72322d7a-a194-4cb1-a43c-ef7f04d5ca1c"),
                            Apellidos = "Olivera",
                            Contrasena = "Admin1",
                            CorreoElectronico = "carlos@gmail.com",
                            EmailConfirmado = false,
                            FechaRegistro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = 0,
                            Nombres = "Carlos",
                            Rol = "Administrador"
                        });
                });

            modelBuilder.Entity("LionDev.Models.OrdenItem", b =>
                {
                    b.HasOne("LionDev.Models.Orden", null)
                        .WithMany("OrdenItems")
                        .HasForeignKey("OrdenId");
                });

            modelBuilder.Entity("LionDev.Models.Producto", b =>
                {
                    b.HasOne("LionDev.Models.Marca", "Marca")
                        .WithMany("Producto")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("LionDev.Models.ProductoColor", b =>
                {
                    b.HasOne("LionDev.Models.Color", "Color")
                        .WithMany("ProductoColores")
                        .HasForeignKey("ColorIdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LionDev.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("LionDev.Models.ProductoTalla", b =>
                {
                    b.HasOne("LionDev.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LionDev.Models.Talla", "Talla")
                        .WithMany("ProductoTallas")
                        .HasForeignKey("TallaIdTalla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Talla");
                });

            modelBuilder.Entity("LionDev.Models.Color", b =>
                {
                    b.Navigation("ProductoColores");
                });

            modelBuilder.Entity("LionDev.Models.Marca", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("LionDev.Models.Orden", b =>
                {
                    b.Navigation("OrdenItems");
                });

            modelBuilder.Entity("LionDev.Models.Talla", b =>
                {
                    b.Navigation("ProductoTallas");
                });
#pragma warning restore 612, 618
        }
    }
}
