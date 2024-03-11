using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
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

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("50834e10-050a-4a89-9e04-cf640c6c6864"), 15, "Blanco y rojo", "Falda larga", true, "Falda larga", "Femenino", "FL3", "14", "ProductosImagenes/FL3.png", 35000 },
                    { new Guid("53c2e6c9-077a-4ffc-83b3-dcf976761eea"), 15, "Negro", "Chaqueta", true, "Chaqueta", "Masculino", "C3", "14", "ProductosImagenes/C3.png", 140000 },
                    { new Guid("e2ecd84f-6005-43f2-a657-0b1bf7e0e7e5"), 25, "Blanco", "Camiseta corta", true, "Camiseta", "Femenino", "CA5", "16", "ProductosImagenes/CA5.png", 45000 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Direccion", "Genero", "Nombres", "NumeroDeDocumento", "Rol", "TipoDeDocumento" },
                values: new object[,]
                {
                    { new Guid("0a3d4e55-2e51-490c-84e6-af8daf1e602f"), "Falcao", "Rada1", "rada@gmail.com", "Calle 1", "Masculino", "Radamel", "12345", "Comprador", "Cedula" },
                    { new Guid("ddc7b9c9-81c4-4f6a-aa2e-4c42e37608d4"), "Rodriguez", "James1", "james@gmail.com", "Calle 2", "Masculino", "James", "12346", "Administrador", "Cedula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("50834e10-050a-4a89-9e04-cf640c6c6864"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("53c2e6c9-077a-4ffc-83b3-dcf976761eea"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("e2ecd84f-6005-43f2-a657-0b1bf7e0e7e5"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("0a3d4e55-2e51-490c-84e6-af8daf1e602f"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("ddc7b9c9-81c4-4f6a-aa2e-4c42e37608d4"));

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
