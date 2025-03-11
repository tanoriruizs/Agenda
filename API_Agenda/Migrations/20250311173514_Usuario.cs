using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Agenda.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Correo", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1252), "Juan Pérez", "1234567890" },
                    { 2, "maria.garcia@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1255), "María García", "0987654321" },
                    { 3, "carlos.lopez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1257), "Carlos López", "5555555555" },
                    { 4, "ana.martinez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1259), "Ana Martínez", "1111111111" },
                    { 5, "luis.rodriguez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1261), "Luis Rodríguez", "2222222222" },
                    { 6, "sofia.hernandez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1262), "Sofía Hernández", "3333333333" },
                    { 7, "pedro.diaz@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1264), "Pedro Díaz", "4444444444" },
                    { 8, "lucia.sanchez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1266), "Lucía Sánchez", "6666666666" },
                    { 9, "jorge.ramirez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1268), "Jorge Ramírez", "7777777777" },
                    { 10, "elena.torres@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1269), "Elena Torres", "8888888888" },
                    { 11, "gabriel.fernandez@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1271), "Gabriel Fernández", "9999999999" },
                    { 12, "natalia.ortega@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1273), "Natalia Ortega", "1010101010" },
                    { 13, "fernando.ruiz@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1274), "Fernando Ruiz", "1212121212" },
                    { 14, "paula.castro@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1276), "Paula Castro", "1313131313" },
                    { 15, "raul.mendoza@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1278), "Raúl Mendoza", "1414141414" },
                    { 16, "andrea.vega@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1280), "Andrea Vega", "1515151515" },
                    { 17, "santiago.guzman@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1281), "Santiago Guzmán", "1616161616" },
                    { 18, "valeria.navarro@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1283), "Valeria Navarro", "1717171717" },
                    { 19, "ricardo.soto@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1285), "Ricardo Soto", "1818181818" },
                    { 20, "isabel.romero@example.com", new DateTime(2025, 3, 11, 10, 35, 14, 710, DateTimeKind.Local).AddTicks(1286), "Isabel Romero", "1919191919" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
