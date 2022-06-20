using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data.ORM.Migrations
{
    public partial class createGeneroUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idImdb",
                table: "Genero",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idImdb",
                table: "Genero");
        }
    }
}
