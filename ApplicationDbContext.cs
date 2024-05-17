using Microsoft.EntityFrameworkCore;
using LionDev.Models;
using System;

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
        public DbSet<PendingUsuario> PendingUsuarios { get; set; }


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

            // Seeds para Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
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


            // Guids para Marca
            var fashionNovaXId = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1");

            // Seeds para Marca
            modelBuilder.Entity<Marca>().HasData(
                new Marca { IdMarca = fashionNovaXId, Nombre = "FASHION NOVA X" }
            );

            // Relación entre Producto y Marca
            modelBuilder.Entity<Producto>()
                .HasOne(df => df.Marca)
                .WithMany(f => f.Producto)
                .HasForeignKey(df => df.IdMarca);

            // Seeds para Producto
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = Guid.Parse("2d98ccdb-9393-4d36-998b-7b1ad994e8e0"),
                    Nombre = "Camisa de vestir negra con rayas sutiles",
                    Referencia = "CL001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpj0mjV27AORratnF?e=fqKpgO",
                    Descripcion = "Distintiva y elegante, esta camisa de vestir negra cuenta con un diseño de rayas sutiles que le añade textura y profundidad. Las rayas finas complementan el color negro, mientras que el corte y estilo clásicos aseguran versatilidad para cualquier ocasión formal.",
                    Color = "Negro",
                    Cantidad = 100,
                    Talla = "M",
                    Valor = 25,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")
                },
                new Producto
                {
                    IdProducto = Guid.Parse("17e15c41-cec7-4ed6-a393-d7e0198e93d1"),
                    Nombre = "Camisa casual negra para mujer",
                    Referencia = "PAE001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkCS4J54_owfge8W?e=E5cCWw",
                    Descripcion = "Esta camisa negra para mujer combina comodidad y estilo con su corte relajado y femenino. El tejido suave y fluido asegura una caída elegante, ideal para un atuendo chic y cómodo. El color negro profundo proporciona una base versátil y sofisticada para diversos looks.",
                    Color = "Negro",
                    Cantidad = 50,
                    Talla = "L",
                    Valor = 30,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Femenino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")

                },
                new Producto
                {
                    IdProducto = Guid.Parse("fba5415e-7d4b-42c7-8507-6665aaf257f5"),
                    Nombre = "Camisa de denim verde para mujer",
                    Referencia = "CJJ001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi4bbUEdiChClAsk?e=J0gbK1",
                    Descripcion = "Esta camisa de denim para mujer en un tono verde terroso combina estilo y practicidad. Con un diseño entallado, cuello definido, botones frontales y bolsillos en el pecho, ofrece una mezcla perfecta de moda y funcionalidad. El tejido de denim duradero y el color verde rico proporcionan un look contemporáneo y chic.",
                    Color = "Verde",
                    Cantidad = 70,
                    Talla = "L",
                    Valor = 34,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Femenino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")
                },
                new Producto
                {
                    IdProducto = Guid.Parse("26f32682-a2d8-4388-82ce-c4bf421317ad"),
                    Nombre = "Camisa de denim azul para hombre",
                    Referencia = "CKH001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpjSYxXw65EDf-FH_?e=gsaGkp",
                    Descripcion = "Representando la esencia del vestuario masculino, esta camisa de denim azul ofrece un ajuste clásico con cuello resistente, botones frontales y bolsillos en el pecho. El color azul profundo y el tejido de denim robusto la convierten en una opción durable y siempre en estilo para el hombre moderno.",
                    Color = "Azul",
                    Cantidad = 60,
                    Talla = "M",
                    Valor = 36,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")
                },
                new Producto
                {
                    IdProducto = Guid.Parse("52e996d1-cc5f-4552-a74c-48257860c171"),
                    Nombre = "Polo azul para hombre",
                    Referencia = "PS001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi9NCvaItrYntnUW?e=3mn8YK",
                    Descripcion = "Esta camisa polo azul para hombre destaca por su tejido piqué suave y transpirable, ofreciendo un ajuste clásico con cuello y placa de botones. El color azul profundo y el diseño elegante la hacen perfecta para ocasiones casuales o semi-formales, reflejando un estilo deportivo y refinado.",
                    Color = "Azul",
                    Cantidad = 80,
                    Talla = "S",
                    Valor = 45,
                    EsDeLosMasBuscados = false,
                    ParaSexo = "Masculino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")
                },
                new Producto
                {
                    IdProducto = Guid.Parse("aa19593d-55f6-4380-a73a-1c48168d0b8d"),
                    Nombre = "Polo verde para mujer",
                    Referencia = "SA001",
                    UrlImagen = "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkL_drp6tX5BfRmN?e=GDLN5j",
                    Descripcion = "Esta camisa polo para mujer en un tono verde vibrante cuenta con un ajuste a medida, cuello elegante y placa de botones. Fabricada en tejido piqué suave y transpirable, combina elegancia con funcionalidad, ideal para llevar en actividades activas o como parte de un atuendo casual elegante.",
                    Color = "Verde",
                    Cantidad = 90,
                    Talla = "XL",
                    Valor = 43,
                    EsDeLosMasBuscados = true,
                    ParaSexo = "Femenino",
                    IdMarca = Guid.Parse("b7db804a-509d-48c8-9512-4d4671c71fd1")
                }

            );


        }
    }
}