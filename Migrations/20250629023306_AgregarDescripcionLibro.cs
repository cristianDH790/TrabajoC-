using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisualizadorEstructuras.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDescripcionLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Libros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 11,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Descripcion",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Libros");
        }
    }
}
