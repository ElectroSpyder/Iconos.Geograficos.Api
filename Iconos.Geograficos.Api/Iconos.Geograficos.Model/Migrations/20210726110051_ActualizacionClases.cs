using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconos.Geograficos.Model.Migrations
{
    public partial class ActualizacionClases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iconos_Ciudades_IdCiudad1",
                table: "Iconos");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Iconos");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Continentes");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Ciudades");

            migrationBuilder.RenameColumn(
                name: "IdCiudad1",
                table: "Iconos",
                newName: "CiudadIdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_Iconos_IdCiudad1",
                table: "Iconos",
                newName: "IX_Iconos_CiudadIdCiudad");

            migrationBuilder.AddColumn<int>(
                name: "IdCiudad",
                table: "Iconos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Iconos_Ciudades_CiudadIdCiudad",
                table: "Iconos",
                column: "CiudadIdCiudad",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iconos_Ciudades_CiudadIdCiudad",
                table: "Iconos");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "Iconos");

            migrationBuilder.RenameColumn(
                name: "CiudadIdCiudad",
                table: "Iconos",
                newName: "IdCiudad1");

            migrationBuilder.RenameIndex(
                name: "IX_Iconos_CiudadIdCiudad",
                table: "Iconos",
                newName: "IX_Iconos_IdCiudad1");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Iconos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Continentes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Ciudades",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Iconos_Ciudades_IdCiudad1",
                table: "Iconos",
                column: "IdCiudad1",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
