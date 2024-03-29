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
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Talla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    EsDeLosMasBuscados = table.Column<bool>(type: "bit", nullable: false),
                    ParaSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarca = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "IdMarca", "Nombre" },
                values: new object[,]
                {
                    { new Guid("07717305-31c4-40b5-958e-072a83e9e45f"), "AMAZON ESSENTIALS" },
                    { new Guid("4254f250-dc80-4097-9015-2faf7fe12659"), "JACK & JONES" },
                    { new Guid("b7db804a-509d-48c8-9512-4d4671c71fd1"), "LEVI’S" },
                    { new Guid("dc06829b-e50b-4ae1-9695-818b3f9aeccd"), "KAYHAN" },
                    { new Guid("eaa1e975-861c-4c31-aee9-6c13277d4750"), "APOONABA" },
                    { new Guid("fcf5bc09-867d-425a-88e9-b1e476fedb6c"), "SPRINGFIELD" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellidos", "Contrasena", "CorreoElectronico", "Nombres", "Rol" },
                values: new object[,]
                {
                    { new Guid("75af7b3f-82c6-4f31-a1bf-0b8e549f57f0"), "Falcao", "Rada1", "rada@gmail.com", "Radamel", "Comprador" },
                    { new Guid("b7f31535-d24d-443e-948e-6f02a1948830"), "Olivera", "Admin1", "carlos@gmail.com", "Carlos", "Administrador" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdMarca",
                table: "Productos",
                column: "IdMarca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
