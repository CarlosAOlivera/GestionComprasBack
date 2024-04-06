using Microsoft.EntityFrameworkCore;
using LionDev.Models;
using System;
using Backend.Migrations;

namespace LionDev
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Entities
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<ProductoColor> ProductoColores { get; set; }
        public DbSet<ProductoTalla> ProductoTallas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to ensure it's not overwritten
            base.OnModelCreating(modelBuilder);

            // Configure keys and relationships
            modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
            modelBuilder.Entity<Marca>().HasKey(m => m.IdMarca);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Color>().HasKey(c => c.IdColor);
            modelBuilder.Entity<Talla>().HasKey(t => t.IdTalla);
            modelBuilder.Entity<ProductoColor>().HasKey(pc => new { pc.IdProducto, pc.IdColor });
            modelBuilder.Entity<ProductoTalla>().HasKey(pt => new { pt.IdProducto, pt.IdTalla });

            modelBuilder.Entity<Producto>()
                .HasOne(df => df.Marca)
                .WithMany(f => f.Producto)
                //.WithMany()
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
                    IdUsuario = Guid.Parse("9b380e62-52f2-4fe6-a0fc-99664828f3af"), 
                    Nombres = "Radamel",
                    Apellidos = "Falcao",
                    CorreoElectronico = "rada@gmail.com",
                    Contrasena = "Rada1",
                    Rol = "Comprador"
                },
                new Usuario
                {
                    IdUsuario = Guid.Parse("72322d7a-a194-4cb1-a43c-ef7f04d5ca1c"),
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
                    IdProducto = Guid.Parse("2d98ccdb-9393-4d36-998b-7b1ad994e8e0"),
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
                    IdProducto = Guid.Parse("17e15c41-cec7-4ed6-a393-d7e0198e93d1"),
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
                    IdProducto = Guid.Parse("fba5415e-7d4b-42c7-8507-6665aaf257f5"),
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
                    IdProducto = Guid.Parse("26f32682-a2d8-4388-82ce-c4bf421317ad"),
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
                    IdProducto = Guid.Parse("52e996d1-cc5f-4552-a74c-48257860c171"),
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
                    IdProducto = Guid.Parse("aa19593d-55f6-4380-a73a-1c48168d0b8d"),
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