using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class cv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("80c481f4-2c24-4289-bfe7-0dae0928eb83"), 25, "Blanco", "Camiseta corta", true, "Camiseta", "Femenino", "CA5", "16", "ProductosImagenes/CA5.png", 45000 },
                    { new Guid("da43d14c-0557-42b6-89b3-1831e195701f"), 15, "Negro", "Chaqueta", true, "Chaqueta", "Masculino", "C3", "14", "ProductosImagenes/C3.png", 140000 },
                    { new Guid("e1b26ab7-c2c1-4900-95cb-113f17eb6b6e"), 15, "Blanco y rojo", "Falda larga", true, "Falda larga", "Femenino", "FL3", "14", "ProductosImagenes/FL3.png", 35000 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Nombres", "Rol" },
                values: new object[,]
                {
                    { new Guid("4bb03cec-6850-409b-b888-1ad38b838f40"), "Olivera", "Admin1", "carlos@gmail.com", "Carlos", "Administrador" },
                    { new Guid("50c9c421-fc48-44f3-9b9a-0935651aecbe"), "Falcao", "Rada1", "rada@gmail.com", "Radamel", "Comprador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("80c481f4-2c24-4289-bfe7-0dae0928eb83"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("da43d14c-0557-42b6-89b3-1831e195701f"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("e1b26ab7-c2c1-4900-95cb-113f17eb6b6e"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("4bb03cec-6850-409b-b888-1ad38b838f40"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("50c9c421-fc48-44f3-9b9a-0935651aecbe"));

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
    }
}
