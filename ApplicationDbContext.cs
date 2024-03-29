using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionDev.Models;

namespace LionDev
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                   : base(options)
        { }

        //public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //public DbSet<Factura> Facturas { get; set; }
        public DbSet<Marca> Marcas { get; set; }        

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<ProductoColor> ProductoColores { get; set; }
        public DbSet<ProductoTalla> ProductoTallas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relaciones y configuraciones de modelos aquí usando Fluent API

            //Las PKs
            //modelBuilder.Entity<DetalleFactura>()
            //    .HasKey(df => df.IdDetalleFactura);

            modelBuilder.Entity<Producto>()
                .HasKey(df => df.IdProducto);

            modelBuilder.Entity<Usuario>()
               .HasKey(df => df.IdUsuario);

            //modelBuilder.Entity<Factura>()
            //    .HasKey(df => df.IdFactura);

            modelBuilder.Entity<Marca>()
                .HasKey(df => df.IdMarca);

            modelBuilder.Entity<ProductoColor>()
                .HasKey(pc => new { pc.IdProducto, pc.IdColor });

            modelBuilder.Entity<ProductoTalla>()
                .HasKey(pt => new { pt.IdProducto, pt.IdTalla });

            //modelBuilder.Entity<DetalleFactura>()
            //    .Property(df => df.Cantidad)
            //    .IsRequired();

            //Las relaciones
            //modelBuilder.Entity<DetalleFactura>()
            //    .HasOne(df => df.Factura)
            //    .WithMany(f => f.DetalleFactura)
            //    .HasForeignKey(df => df.IdFactura);

            //modelBuilder.Entity<Factura>()
            //    .HasOne(df => df.Comprador)
            //    .WithMany(f => f.Factura)
            //    .HasForeignKey(df => df.IdComprador);

            //modelBuilder.Entity<DetalleFactura>()
            //    .HasOne(df => df.Producto)
            //    .WithMany(f => f.DetalleFactura)
            //    .HasForeignKey(df => df.IdProducto);

            //modelBuilder.Entity<Producto>()
            //    .HasOne(df => df.Marca)
            //    .WithMany(f => f.Producto)
            //    .HasForeignKey(df => df.IdMarca);

            modelBuilder.Entity<Producto>()
                .HasOne(df => df.Marca)
                .WithMany(f => f.Producto)
                .HasForeignKey(df => df.IdMarca);

            // Seeds para Marca
            var levisId = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1");
            var guessId = Guid.Parse("07717305-31c4-40b5-958e-072a83e9e45f");
            var jackJonesId = Guid.Parse("4254f250-dc80-4097-9015-2faf7fe12659");
            var kayhanHombreId = Guid.Parse("dc06829b-e50b-4ae1-9695-818b3f9aeccd");
            var springfieldId = Guid.Parse("fcf5bc09-867d-425a-88e9-b1e476fedb6c");
            var apoonabaId = Guid.Parse("eaa1e975-861c-4c31-aee9-6c13277d4750");


            modelBuilder.Entity<Marca>().HasData(
                new Marca { IdMarca = levisId, Nombre = "LEVI’S" },
                new Marca { IdMarca = guessId, Nombre = "AMAZON ESSENTIALS" },
                new Marca { IdMarca = jackJonesId, Nombre = "JACK & JONES" },
                new Marca { IdMarca = kayhanHombreId, Nombre = "KAYHAN" },
                new Marca { IdMarca = springfieldId, Nombre = "SPRINGFIELD" },
                new Marca { IdMarca = apoonabaId, Nombre = "APOONABA" }
            );

            // Seeds para Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { 
                    IdUsuario = Guid.NewGuid(), 
                    Nombres = "Radamel",
                    Apellidos = "Falcao",
                    CorreoElectronico = "rada@gmail.com",
                    Contrasena = "Rada1",
                    Rol = "Comprador"
                },
                new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombres = "Carlos",
                    Apellidos = "Olivera",
                    CorreoElectronico = "carlos@gmail.com",
                    Contrasena = "Admin1",
                    Rol = "Administrador"
                }
            );

            // Seeds para Producto
            modelBuilder.Entity<Producto>().HasData(              
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Camiseta Levi's Original",
                    Referencia = "CL001",
                    UrlImagen = "images/levis-camiseta.jpg",
                    Descripcion = "Camiseta clásica Levi’s",
                    Color = "Azul",
                    Cantidad = 100,
                    Talla = "M",
                    Valor = 29900,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = levisId
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Pantalón Guess",
                    Referencia = "PAE001",
                    UrlImagen = "images/amazon-essentials-pantalon.jpg",
                    Descripcion = "Pantalón cómodo Amazon Essentials",
                    Color = "Negro",
                    Cantidad = 50,
                    Talla = "L",
                    Valor = 45900,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Femenino",
                    IdMarca = guessId

                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Chaqueta JACK & JONES",
                    Referencia = "CJJ001",
                    UrlImagen = "images/jackjones.jpg",
                    Descripcion = "Chaqueta moderna JACK & JONES en negro",
                    Color = "Negro",
                    Cantidad = 70,
                    Talla = "L",
                    Valor = 75000,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = jackJonesId
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Camisa Kayhan Hombre",
                    Referencia = "CKH001",
                    UrlImagen = "images/kayhanman.jpg",
                    Descripcion = "Camisa elegante Kayhan en blanco",
                    Color = "Blanco",
                    Cantidad = 60,
                    Talla = "M",
                    Valor = 60000,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = kayhanHombreId
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Polo SPRINGFIELD",
                    Referencia = "PS001",
                    UrlImagen = "images/springfield.jpg",
                    Descripcion = "Polo casual SPRINGFIELD en verde",
                    Color = "Verde",
                    Cantidad = 80,
                    Talla = "S",
                    Valor = 45000,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = springfieldId
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Sudadera APOONABA",
                    Referencia = "SA001",
                    UrlImagen = "images/apoonaba.jpg",
                    Descripcion = "Sudadera APOONABA confortable en gris",
                    Color = "Gris",
                    Cantidad = 90,
                    Talla = "XL",
                    Valor = 65000,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Unisex",
                    IdMarca = apoonabaId
                }

            );

            
    }
}
}