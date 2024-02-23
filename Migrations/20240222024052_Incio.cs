using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Incio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    IdComprador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TipoDeDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumeroDeDocumento = table.Column<int>(type: "int", maxLength: 16, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.IdComprador);
                });

            migrationBuilder.InsertData(
                table: "Compradores",
                columns: new[] { "IdComprador", "Apellidos", "Contrasena", "CorreoElectronico", "Direccion", "Genero", "Nombres", "NumeroDeDocumento", "Rol", "TipoDeDocumento" },
                values: new object[,]
                {
                    { new Guid("876e1c21-42e3-45bb-bd56-291b5a6e6844"), "Falcao", "Rada1", "rada@gmail.com", "Calle 1", "Masculino", "Radamel", 12345, "Administrador", "Cedula" },
                    { new Guid("abeed370-8e6e-4121-879d-bc982f5aaac4"), "Rodriguez", "James1", "james@gmail.com", "Calle 2", "Masculino", "James", 12346, "Empleado", "Cedula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compradores");
        }
    }
}
