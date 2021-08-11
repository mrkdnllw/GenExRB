using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _958a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "FeatureData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FeatureData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
