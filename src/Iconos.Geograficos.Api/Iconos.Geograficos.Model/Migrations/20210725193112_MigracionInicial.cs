using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconos.Geograficos.Model.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continentes",
                columns: table => new
                {
                    IdContinente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continentes", x => x.IdContinente);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadHabitantes = table.Column<int>(type: "int", nullable: false),
                    SuperficieTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IdContinente = table.Column<int>(type: "int", nullable: false),
                    ContinenteIdContinente = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudades_Continentes_ContinenteIdContinente",
                        column: x => x.ContinenteIdContinente,
                        principalTable: "Continentes",
                        principalColumn: "IdContinente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iconos",
                columns: table => new
                {
                    IdIcono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCiudad1 = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iconos", x => x.IdIcono);
                    table.ForeignKey(
                        name: "FK_Iconos_Ciudades_IdCiudad1",
                        column: x => x.IdCiudad1,
                        principalTable: "Ciudades",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ContinenteIdContinente",
                table: "Ciudades",
                column: "ContinenteIdContinente");

            migrationBuilder.CreateIndex(
                name: "IX_Iconos_IdCiudad1",
                table: "Iconos",
                column: "IdCiudad1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iconos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Continentes");
        }
    }
}
