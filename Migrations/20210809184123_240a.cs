using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _240a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "FeatureData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureData_PropertyId",
                table: "FeatureData",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureData_Properties_PropertyId",
                table: "FeatureData",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureData_Properties_PropertyId",
                table: "FeatureData");

            migrationBuilder.DropIndex(
                name: "IX_FeatureData_PropertyId",
                table: "FeatureData");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "FeatureData");
        }
    }
}
