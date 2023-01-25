using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibros.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autor_AutorIdAutor",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libros",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutorIdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutorIdAutor",
                table: "Libros");

            migrationBuilder.RenameTable(
                name: "Libros",
                newName: "Libro");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Libro",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Libro",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libro",
                table: "Libro",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libro",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libro");

            migrationBuilder.RenameTable(
                name: "Libro",
                newName: "Libros");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutorIdAutor",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libros",
                table: "Libros",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorIdAutor",
                table: "Libros",
                column: "AutorIdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autor_AutorIdAutor",
                table: "Libros",
                column: "AutorIdAutor",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
