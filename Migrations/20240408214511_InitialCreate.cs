using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("2dec61e1-bdf2-4812-9b7f-629981f445fb"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("35c9fe8f-5419-495a-bbfe-22473b3cea4b"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("655360b2-9b43-4119-ba75-6791e2782e5a"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("5630ff27-8c29-407c-9263-e35be20c634c"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("5d1d4802-13c3-4c72-8d73-70d104af9af2"));

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroDeDocumento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoDeDocumento",
                table: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "IdMarca",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    IdColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Tallas",
                columns: table => new
                {
                    IdTalla = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallas", x => x.IdTalla);
                });

            migrationBuilder.CreateTable(
                name: "ProductoColores",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoIdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorIdColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoColores", x => new { x.IdProducto, x.IdColor });
                    table.ForeignKey(
                        name: "FK_ProductoColores_Colores_ColorIdColor",
                        column: x => x.ColorIdColor,
                        principalTable: "Colores",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoColores_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTallas",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTalla = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoIdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TallaIdTalla = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTallas", x => new { x.IdProducto, x.IdTalla });
                    table.ForeignKey(
                        name: "FK_ProductoTallas_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTallas_Tallas_TallaIdTalla",
                        column: x => x.TallaIdTalla,
                        principalTable: "Tallas",
                        principalColumn: "IdTalla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "IdMarca", "Nombre" },
                values: new object[] { new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "FASHION NOVA X" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Nombres", "Rol" },
                values: new object[,]
                {
                    { new Guid("72322d7a-a194-4cb1-a43c-ef7f04d5ca1c"), "Olivera", "Admin1", "carlos@gmail.com", "Carlos", "Administrador" },
                    { new Guid("9b380e62-52f2-4fe6-a0fc-99664828f3af"), "Falcao", "Rada1", "rada@gmail.com", "Radamel", "Comprador" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "IdMarca", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("17e15c41-cec7-4ed6-a393-d7e0198e93d1"), 50, "Negro", "Esta camisa negra para mujer combina comodidad y estilo con su corte relajado y femenino. El tejido suave y fluido asegura una caída elegante, ideal para un atuendo chic y cómodo. El color negro profundo proporciona una base versátil y sofisticada para diversos looks.", true, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camisa casual negra para mujer", "Femenino", "PAE001", "L", "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkCS4J54_owfge8W?e=E5cCWw", 30 },
                    { new Guid("26f32682-a2d8-4388-82ce-c4bf421317ad"), 60, "Azul", "Representando la esencia del vestuario masculino, esta camisa de denim azul ofrece un ajuste clásico con cuello resistente, botones frontales y bolsillos en el pecho. El color azul profundo y el tejido de denim robusto la convierten en una opción durable y siempre en estilo para el hombre moderno.", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camisa de denim azul para hombre", "Masculino", "CKH001", "M", "https://1drv.ms/i/s!Aq7Lcrt8MtbfpjSYxXw65EDf-FH_?e=gsaGkp", 36 },
                    { new Guid("2d98ccdb-9393-4d36-998b-7b1ad994e8e0"), 100, "Negro", "Distintiva y elegante, esta camisa de vestir negra cuenta con un diseño de rayas sutiles que le añade textura y profundidad. Las rayas finas complementan el color negro, mientras que el corte y estilo clásicos aseguran versatilidad para cualquier ocasión formal.", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camisa de vestir negra con rayas sutiles", "Masculino", "CL001", "M", "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpj0mjV27AORratnF?e=fqKpgO", 25 },
                    { new Guid("52e996d1-cc5f-4552-a74c-48257860c171"), 80, "Azul", "Esta camisa polo azul para hombre destaca por su tejido piqué suave y transpirable, ofreciendo un ajuste clásico con cuello y placa de botones. El color azul profundo y el diseño elegante la hacen perfecta para ocasiones casuales o semi-formales, reflejando un estilo deportivo y refinado.", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Polo azul para hombre", "Masculino", "PS001", "S", "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi9NCvaItrYntnUW?e=3mn8YK", 45 },
                    { new Guid("aa19593d-55f6-4380-a73a-1c48168d0b8d"), 90, "Verde", "Esta camisa polo para mujer en un tono verde vibrante cuenta con un ajuste a medida, cuello elegante y placa de botones. Fabricada en tejido piqué suave y transpirable, combina elegancia con funcionalidad, ideal para llevar en actividades activas o como parte de un atuendo casual elegante.", true, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Polo verde para mujer", "Unisex", "SA001", "XL", "https://1drv.ms/i/s!Aq7Lcrt8MtbfpkL_drp6tX5BfRmN?e=GDLN5j", 43 },
                    { new Guid("fba5415e-7d4b-42c7-8507-6665aaf257f5"), 70, "Verde", "Esta camisa de denim para mujer en un tono verde terroso combina estilo y practicidad. Con un diseño entallado, cuello definido, botones frontales y bolsillos en el pecho, ofrece una mezcla perfecta de moda y funcionalidad. El tejido de denim duradero y el color verde rico proporcionan un look contemporáneo y chic.", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camisa de denim verde para mujer", "Masculino", "CJJ001", "L", "https://1drv.ms/i/s!Aq7Lcrt8Mtbfpi4bbUEdiChClAsk?e=J0gbK1", 34 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdMarca",
                table: "Productos",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoColores_ColorIdColor",
                table: "ProductoColores",
                column: "ColorIdColor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoColores_ProductoIdProducto",
                table: "ProductoColores",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_ProductoIdProducto",
                table: "ProductoTallas",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_TallaIdTalla",
                table: "ProductoTallas",
                column: "TallaIdTalla");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_IdMarca",
                table: "Productos",
                column: "IdMarca",
                principalTable: "Marcas",
                principalColumn: "IdMarca",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_IdMarca",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "ProductoColores");

            migrationBuilder.DropTable(
                name: "ProductoTallas");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Tallas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdMarca",
                table: "Productos");

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("17e15c41-cec7-4ed6-a393-d7e0198e93d1"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("26f32682-a2d8-4388-82ce-c4bf421317ad"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("2d98ccdb-9393-4d36-998b-7b1ad994e8e0"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("52e996d1-cc5f-4552-a74c-48257860c171"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("aa19593d-55f6-4380-a73a-1c48168d0b8d"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("fba5415e-7d4b-42c7-8507-6665aaf257f5"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("72322d7a-a194-4cb1-a43c-ef7f04d5ca1c"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("9b380e62-52f2-4fe6-a0fc-99664828f3af"));

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Usuarios",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDeDocumento",
                table: "Usuarios",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeDocumento",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("2dec61e1-bdf2-4812-9b7f-629981f445fb"), 15, "Blanco y rojo", "Falda larga", true, "Falda larga", "Femenino", "FL3", "14", "ProductosImagenes/FL3.png", 35000 },
                    { new Guid("35c9fe8f-5419-495a-bbfe-22473b3cea4b"), 25, "Blanco", "Camiseta corta", true, "Camiseta", "Femenino", "CA5", "16", "ProductosImagenes/CA5.png", 45000 },
                    { new Guid("655360b2-9b43-4119-ba75-6791e2782e5a"), 15, "Negro", "Chaqueta", true, "Chaqueta", "Masculino", "C3", "14", "ProductosImagenes/C3.png", 140000 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Direccion", "Genero", "Nombres", "NumeroDeDocumento", "Rol", "TipoDeDocumento" },
                values: new object[,]
                {
                    { new Guid("5630ff27-8c29-407c-9263-e35be20c634c"), "Falcao", "Rada1", "rada@gmail.com", "Calle 1", "Masculino", "Radamel", "12345", "Comprador", "Cedula" },
                    { new Guid("5d1d4802-13c3-4c72-8d73-70d104af9af2"), "Rodriguez", "James1", "james@gmail.com", "Calle 2", "Masculino", "James", "12346", "Administrador", "Cedula" }
                });
        }
    }
}
