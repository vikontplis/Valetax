using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Infrastructure.Migrations
{
    public partial class AddTreeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<long>(
                name: "TreeId",
                table: "Nodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreeId",
                table: "Nodes");

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1L, "Root", null });
        }
    }
}
