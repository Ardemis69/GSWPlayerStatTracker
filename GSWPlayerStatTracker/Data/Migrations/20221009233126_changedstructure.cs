using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSWPlayerStatTracker.Data.Migrations
{
    public partial class changedstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Player");
        }
    }
}
