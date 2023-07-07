using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace club.Migrations
{
    public partial class ng1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Membre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membre_ClubId",
                table: "Membre",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membre_Club_ClubId",
                table: "Membre",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id");
        }
    }
}
