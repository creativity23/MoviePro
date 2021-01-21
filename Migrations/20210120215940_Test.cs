using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePro.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Studioid",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Studioid",
                table: "Movies",
                column: "Studioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Studios_Studioid",
                table: "Movies",
                column: "Studioid",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Studios_Studioid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Studioid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Studioid",
                table: "Movies");
        }
    }
}
