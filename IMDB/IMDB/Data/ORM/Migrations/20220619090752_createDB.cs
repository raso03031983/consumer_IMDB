using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data.ORM.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idIMDB = table.Column<int>(type: "int", nullable: false),
                    adult = table.Column<bool>(type: "bit", nullable: false),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<double>(type: "float", nullable: false),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video = table.Column<bool>(type: "bit", nullable: false),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
