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
//using System.Data.Entity;

namespace LionDev
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                   : base(options)
        { }

        //public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        //public DbSet<Producto> Productos { get; set; }
        //public DbSet<Factura> Facturas { get; set; }
        //public DbSet<Marca> Marcas { get; set; }
        public DbSet<Comprador> Compradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones y configuraciones de modelos aquí usando Fluent API

            //Las PKs
            //modelBuilder.Entity<DetalleFactura>()
            //    .HasKey(df => df.IdDetalleFactura);

            //modelBuilder.Entity<Producto>()
            //    .HasKey(df => df.IdProducto);

            //modelBuilder.Entity<Factura>()
            //    .HasKey(df => df.IdFactura);

            //modelBuilder.Entity<Marca>()
            //    .HasKey(df => df.IdMarca);

            modelBuilder.Entity<Comprador>()
                .HasKey(df => df.IdComprador);

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

            //Reglas de los campos
            modelBuilder.Entity<Comprador>(entity =>
            {
                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)"); // Tipo de columna y longitud en la base de datos

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");

                entity.Property(e => e.TipoDeDocumento)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");

                entity.Property(e => e.NumeroDeDocumento)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode();

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode()
                    .HasColumnType("nvarchar(9)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode()
                    .HasColumnType("nvarchar(30)");
            });


            // Seeds
            modelBuilder.Entity<Comprador>().HasData(
                new Comprador { IdComprador = Guid.NewGuid(), 
                    Nombres = "Radamel",
                    Apellidos = "Falcao",
                    CorreoElectronico = "rada@gmail.com",
                    TipoDeDocumento = "Cedula",
                    NumeroDeDocumento = 12345,
                    Contrasena = "Rada1",
                    Genero = "Masculino",
                    Direccion = "Calle 1",
                    Rol = "Administrador"
                },
                new Comprador
                {
                    IdComprador = Guid.NewGuid(),
                    Nombres = "James",
                    Apellidos = "Rodriguez",
                    CorreoElectronico = "james@gmail.com",
                    TipoDeDocumento = "Cedula",
                    NumeroDeDocumento = 12346,
                    Contrasena = "James1",
                    Genero = "Masculino",
                    Direccion = "Calle 2",
                    Rol = "Empleado"
                }         
            );     


            base.OnModelCreating(modelBuilder);
    }
}
}
