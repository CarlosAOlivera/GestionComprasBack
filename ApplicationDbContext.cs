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
        //public DbSet<Marca> Marcas { get; set; }        
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            //modelBuilder.Entity<Marca>()
            //    .HasKey(df => df.IdMarca);         

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

            // Seeds
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { 
                    IdUsuario = Guid.NewGuid(), 
                    Nombres = "Radamel",
                    Apellidos = "Falcao",
                    CorreoElectronico = "rada@gmail.com",
                    //TipoDeDocumento = "Cedula",
                    //NumeroDeDocumento = "12345",
                    Contrasena = "Rada1",
                    //Genero = "Masculino",
                    //Direccion = "Calle 1",
                    Rol = "Comprador"
                },
                new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombres = "Carlos",
                    Apellidos = "Olivera",
                    CorreoElectronico = "carlos@gmail.com",
                    //TipoDeDocumento = "Cedula",
                    //NumeroDeDocumento = "12346",
                    Contrasena = "Admin1",
                    //Genero = "Masculino",
                    //Direccion = "Calle 2",
                    Rol = "Administrador"
                }
            );

            modelBuilder.Entity<Producto>().HasData(              
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Chaqueta",
                    Referencia = "C3",
                    UrlImagen = "ProductosImagenes/C3.png",
                    Descripcion = "Chaqueta",
                    Color = "Negro",
                    Cantidad = 15,
                    Talla = "14",
                    Valor = 140000,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Masculino"
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Falda larga",
                    Referencia = "FL3",
                    UrlImagen = "ProductosImagenes/FL3.png",
                    Descripcion = "Falda larga",
                    Color = "Blanco y rojo",
                    Cantidad = 15,
                    Talla = "14",
                    Valor = 35000,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Femenino"
                },
                new Producto
                {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Camiseta",
                    Referencia = "CA5",
                    UrlImagen = "ProductosImagenes/CA5.png",
                    Descripcion = "Camiseta corta",
                    Color = "Blanco",
                    Cantidad = 25,
                    Talla = "16",
                    Valor = 45000,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Femenino"
                }
            );


            base.OnModelCreating(modelBuilder);
    }
}
}
