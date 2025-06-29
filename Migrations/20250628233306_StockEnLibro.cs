using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VisualizadorEstructuras.Migrations
{
    /// <inheritdoc />
    public partial class StockEnLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Libros de narrativa ficticia", "Ficción" },
                    { 2, "Libros basados en hechos reales", "No Ficción" },
                    { 3, "Libros de estudio y referencia", "Académico" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "Anio", "Autor", "Categoria", "Disponible", "FechaDevolucion", "FechaPrestamo", "ISBN", "NombreUsuario", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 1, 1967, "Gabriel García Márquez", "Ficción", true, null, null, "978-0307474728", null, 2, "Cien Años de Soledad" },
                    { 2, 1963, "Julio Cortázar", "Ficción", true, null, null, "978-8437604947", null, 2, "Rayuela" },
                    { 3, 1605, "Miguel de Cervantes", "Ficción", true, null, null, "978-8491050297", null, 2, "Don Quijote de la Mancha" },
                    { 4, 1949, "Jorge Luis Borges", "Ficción", true, null, null, "978-8426404187", null, 2, "El Aleph" },
                    { 5, 2011, "Yuval Noah Harari", "No Ficción", true, null, null, "978-8499924213", null, 2, "Sapiens" },
                    { 6, 2018, "Stephen Hawking", "No Ficción", true, null, null, "978-8491392065", null, 2, "Breves respuestas a las grandes preguntas" },
                    { 7, 1947, "Ana Frank", "No Ficción", true, null, null, "978-8497593794", null, 2, "El diario de Ana Frank" },
                    { 8, 1997, "Miguel Ruiz", "No Ficción", true, null, null, "978-1878424310", null, 2, "Los cuatro acuerdos" },
                    { 9, 1941, "Aurelio Baldor", "Académico", true, null, null, "978-9702602532", null, 2, "Álgebra de Baldor" },
                    { 10, 2008, "James Stewart", "Académico", true, null, null, "978-6074817448", null, 2, "Cálculo" },
                    { 11, 2018, "Sears y Zemansky", "Académico", true, null, null, "978-6073223493", null, 2, "Física Universitaria" },
                    { 12, 2010, "Raymond Chang", "Académico", true, null, null, "978-6071509636", null, 2, "Química" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Libros");
        }
    }
}
