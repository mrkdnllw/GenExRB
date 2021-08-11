using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _6a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Value1",
                table: "FeatureData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value1",
                table: "FeatureData");
        }
    }
}
