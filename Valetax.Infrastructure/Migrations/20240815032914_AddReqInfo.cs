using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Infrastructure.Migrations
{
    public partial class AddReqInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Journals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Query",
                table: "Journals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trace",
                table: "Journals",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Query",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Trace",
                table: "Journals");
        }
    }
}
