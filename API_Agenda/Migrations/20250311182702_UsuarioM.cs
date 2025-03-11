using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Agenda.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioM : Migration
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
                    Favorito = table.Column<bool>(type: "bit", nullable: false),
                    ListaNegra = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Correo", "Favorito", "FechaRegistro", "ListaNegra", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8575), true, "Juan Pérez", "1234567890" },
                    { 2, "maria.garcia@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8660), false, "María García", "0987654321" },
                    { 3, "carlos.lopez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8664), true, "Carlos López", "5555555555" },
                    { 4, "ana.martinez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8679), false, "Ana Martínez", "1111111111" },
                    { 5, "luis.rodriguez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8683), false, "Luis Rodríguez", "2222222222" },
                    { 6, "sofia.hernandez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8686), true, "Sofía Hernández", "3333333333" },
                    { 7, "pedro.diaz@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8689), true, "Pedro Díaz", "4444444444" },
                    { 8, "lucia.sanchez@example.com", true, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8695), false, "Lucía Sánchez", "6666666666" },
                    { 9, "jorge.ramirez@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8698), true, "Jorge Ramírez", "7777777777" },
                    { 10, "elena.torres@example.com", false, new DateTime(2025, 3, 11, 11, 27, 2, 574, DateTimeKind.Local).AddTicks(8701), true, "Elena Torres", "8888888888" }
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
