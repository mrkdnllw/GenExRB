using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _334a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.CreateTable(
                name: "FeatureData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureOptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FeatureOptions",
                columns: new[] { "Id", "Key" },
                values: new object[] { 1, "CCTV" });

            migrationBuilder.InsertData(
                table: "FeatureOptions",
                columns: new[] { "Id", "Key" },
                values: new object[] { 2, "Clubhouse" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureData");

            migrationBuilder.DropTable(
                name: "FeatureOptions");

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "CCTV", null });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 2, "Clubhouse", null });
        }
    }
}
