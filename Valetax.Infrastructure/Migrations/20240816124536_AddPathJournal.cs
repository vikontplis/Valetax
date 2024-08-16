using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Infrastructure.Migrations
{
    public partial class AddPathJournal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Journals",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Journals");
        }
    }
}
