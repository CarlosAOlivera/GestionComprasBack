using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValorToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("19beb9bd-9895-4d78-977b-7712b7101989"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("266b7aeb-a1a7-45e3-97ab-326ebe3927b5"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("4876d0aa-2ca7-4bfa-9439-537b320b7dcf"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("936bf0a4-2c93-4aa0-8262-36a49a816228"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("a2513011-de7c-48c3-b18b-e09c02e1f71a"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("f18a586a-a7b6-4992-bb7b-bb669d1751a7"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("75af7b3f-82c6-4f31-a1bf-0b8e549f57f0"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("b7f31535-d24d-443e-948e-6f02a1948830"));

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Productos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "IdMarca", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("0a620f8b-0e2d-4329-a320-8d724cc01bf6"), 100, "Azul", "Camiseta clásica Levi’s", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camiseta Levi's Original", "Masculino", "CL001", "M", "images/levis-camiseta.jpg", 29.99f },
                    { new Guid("254cf01d-3cfa-4ec4-8088-6ad411579388"), 80, "Verde", "Polo casual SPRINGFIELD en verde", false, new Guid("fcf5bc09-867d-425a-88e9-b1e476fedb6c"), "Polo SPRINGFIELD", "Masculino", "PS001", "S", "images/springfield.jpg", 45.55f },
                    { new Guid("2aede0fe-501b-450f-94ba-2c57391a9703"), 50, "Negro", "Pantalón cómodo Amazon Essentials", true, new Guid("07717305-31c4-40b5-958e-072a83e9e45f"), "Pantalón Amazon Essentials", "Femenino", "PAE001", "L", "images/amazon-essentials-pantalon.jpg", 45.9f },
                    { new Guid("33e67a2c-b9d4-4b51-bfca-a434b542fac7"), 70, "Negro", "Chaqueta moderna JACK & JONES en negro", false, new Guid("4254f250-dc80-4097-9015-2faf7fe12659"), "Chaqueta JACK & JONES", "Masculino", "CJJ001", "L", "images/jackjones.jpg", 75f },
                    { new Guid("86096919-9331-4a72-9024-a7b2b08e9be6"), 90, "Gris", "Sudadera APOONABA confortable en gris", true, new Guid("eaa1e975-861c-4c31-aee9-6c13277d4750"), "Sudadera APOONABA", "Unisex", "SA001", "XL", "images/apoonaba.jpg", 65f },
                    { new Guid("862520ce-4ace-4ddd-84a7-301e8beae158"), 60, "Blanco", "Camisa elegante Kayhan en blanco", false, new Guid("dc06829b-e50b-4ae1-9695-818b3f9aeccd"), "Camisa Kayhan Hombre", "Masculino", "CKH001", "M", "images/kayhanman.jpg", 60.99f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Nombres", "Rol" },
                values: new object[,]
                {
                    { new Guid("a49c8a13-35fc-47f4-a7db-3e84cd6ecdea"), "Olivera", "Admin1", "carlos@gmail.com", "Carlos", "Administrador" },
                    { new Guid("d72a2829-93e9-41f4-9d5f-fed9e32e5df7"), "Falcao", "Rada1", "rada@gmail.com", "Radamel", "Comprador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("0a620f8b-0e2d-4329-a320-8d724cc01bf6"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("254cf01d-3cfa-4ec4-8088-6ad411579388"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("2aede0fe-501b-450f-94ba-2c57391a9703"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("33e67a2c-b9d4-4b51-bfca-a434b542fac7"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("86096919-9331-4a72-9024-a7b2b08e9be6"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("862520ce-4ace-4ddd-84a7-301e8beae158"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("a49c8a13-35fc-47f4-a7db-3e84cd6ecdea"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("d72a2829-93e9-41f4-9d5f-fed9e32e5df7"));

            migrationBuilder.AlterColumn<int>(
                name: "Valor",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Cantidad", "Color", "Descripcion", "EsDeLosMasBuscados", "IdMarca", "Nombre", "ParaSexo", "Referencia", "Talla", "UrlImagen", "Valor" },
                values: new object[,]
                {
                    { new Guid("19beb9bd-9895-4d78-977b-7712b7101989"), 90, "Gris", "Sudadera APOONABA confortable en gris", true, new Guid("eaa1e975-861c-4c31-aee9-6c13277d4750"), "Sudadera APOONABA", "Unisex", "SA001", "XL", "images/apoonaba.jpg", 65000 },
                    { new Guid("266b7aeb-a1a7-45e3-97ab-326ebe3927b5"), 100, "Azul", "Camiseta clásica Levi’s", false, new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "Camiseta Levi's Original", "Masculino", "CL001", "M", "images/levis-camiseta.jpg", 29900 },
                    { new Guid("4876d0aa-2ca7-4bfa-9439-537b320b7dcf"), 60, "Blanco", "Camisa elegante Kayhan en blanco", false, new Guid("dc06829b-e50b-4ae1-9695-818b3f9aeccd"), "Camisa Kayhan Hombre", "Masculino", "CKH001", "M", "images/kayhanman.jpg", 60000 },
                    { new Guid("936bf0a4-2c93-4aa0-8262-36a49a816228"), 50, "Negro", "Pantalón cómodo Amazon Essentials", true, new Guid("07717305-31c4-40b5-958e-072a83e9e45f"), "Pantalón Amazon Essentials", "Femenino", "PAE001", "L", "images/amazon-essentials-pantalon.jpg", 45900 },
                    { new Guid("a2513011-de7c-48c3-b18b-e09c02e1f71a"), 80, "Verde", "Polo casual SPRINGFIELD en verde", false, new Guid("fcf5bc09-867d-425a-88e9-b1e476fedb6c"), "Polo SPRINGFIELD", "Masculino", "PS001", "S", "images/springfield.jpg", 45000 },
                    { new Guid("f18a586a-a7b6-4992-bb7b-bb669d1751a7"), 70, "Negro", "Chaqueta moderna JACK & JONES en negro", false, new Guid("4254f250-dc80-4097-9015-2faf7fe12659"), "Chaqueta JACK & JONES", "Masculino", "CJJ001", "L", "images/jackjones.jpg", 75000 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Nombres", "Rol" },
                values: new object[,]
                {
                    { new Guid("75af7b3f-82c6-4f31-a1bf-0b8e549f57f0"), "Falcao", "Rada1", "rada@gmail.com", "Radamel", "Comprador" },
                    { new Guid("b7f31535-d24d-443e-948e-6f02a1948830"), "Olivera", "Admin1", "carlos@gmail.com", "Carlos", "Administrador" }
                });
        }
    }
}
