using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserConfirmationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("aa19593d-55f6-4380-a73a-1c48168d0b8d"),
                column: "ParaSexo",
                value: "Femenino");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("fba5415e-7d4b-42c7-8507-6665aaf257f5"),
                column: "ParaSexo",
                value: "Femenino");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("72322d7a-a194-4cb1-a43c-ef7f04d5ca1c"),
                columns: new[] { "ConfirmationToken", "EmailConfirmado" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: new Guid("9b380e62-52f2-4fe6-a0fc-99664828f3af"),
                columns: new[] { "ConfirmationToken", "EmailConfirmado" },
                values: new object[] { null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmailConfirmado",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("aa19593d-55f6-4380-a73a-1c48168d0b8d"),
                column: "ParaSexo",
                value: "Unisex");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("fba5415e-7d4b-42c7-8507-6665aaf257f5"),
                column: "ParaSexo",
                value: "Masculino");
        }
    }
}
