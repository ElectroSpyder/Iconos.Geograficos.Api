using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconos.Geograficos.Model.Migrations
{
    public partial class AgregandoPropiedadesAImagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenThumbnailUrl",
                table: "Iconos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Iconos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenThumbnailUrl",
                table: "Continentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Continentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenThumbnailUrl",
                table: "Ciudades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Ciudades",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenThumbnailUrl",
                table: "Iconos");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Iconos");

            migrationBuilder.DropColumn(
                name: "ImagenThumbnailUrl",
                table: "Continentes");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Continentes");

            migrationBuilder.DropColumn(
                name: "ImagenThumbnailUrl",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Ciudades");
        }
    }
}
