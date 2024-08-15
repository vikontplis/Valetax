using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Infrastructure.Migrations
{
    public partial class SeedRootNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1L, "Root", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
