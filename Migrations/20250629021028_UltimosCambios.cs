using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VisualizadorEstructuras.Migrations
{
    /// <inheritdoc />
    public partial class UltimosCambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Libros");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaPadreId",
                table: "Categorias",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaPadreId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaPadreId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoriaPadreId",
                value: null);

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CategoriaPadreId", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 4, 1, "Novelas literarias", "Novela" },
                    { 5, 1, "Ciencia ficción y fantasía", "Ciencia Ficción" },
                    { 6, 1, "Novelas de misterio y suspense", "Misterio" },
                    { 7, 2, "Libros de historia", "Historia" },
                    { 8, 2, "Biografías y autobiografías", "Biografía" },
                    { 9, 2, "Libros de divulgación científica", "Ciencia" },
                    { 10, 3, "Libros de matemáticas", "Matemáticas" },
                    { 11, 3, "Libros de física", "Física" },
                    { 12, 3, "Libros de química", "Química" }
                });

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoriaId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoriaId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Anio", "Autor", "CategoriaId", "ISBN", "Titulo" },
                values: new object[] { 1965, "Frank Herbert", 5, "978-0441172719", "Dune" });

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoriaId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoriaId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoriaId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoriaId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoriaId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoriaId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoriaId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 11,
                column: "CategoriaId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 12,
                column: "CategoriaId",
                value: 12);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaPadreId",
                table: "Categorias",
                column: "CategoriaPadreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Categorias_CategoriaPadreId",
                table: "Categorias",
                column: "CategoriaPadreId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Categorias_CategoriaPadreId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_CategoriaId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_CategoriaPadreId",
                table: "Categorias");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "CategoriaPadreId",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Libros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Categoria",
                value: "Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Categoria",
                value: "Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Anio", "Autor", "Categoria", "ISBN", "Titulo" },
                values: new object[] { 1605, "Miguel de Cervantes", "Ficción", "978-8491050297", "Don Quijote de la Mancha" });

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Categoria",
                value: "Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Categoria",
                value: "No Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Categoria",
                value: "No Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Categoria",
                value: "No Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Categoria",
                value: "No Ficción");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Categoria",
                value: "Académico");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10,
                column: "Categoria",
                value: "Académico");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 11,
                column: "Categoria",
                value: "Académico");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Categoria",
                value: "Académico");
        }
    }
}
