using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
