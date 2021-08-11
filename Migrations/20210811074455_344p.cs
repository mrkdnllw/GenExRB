using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _344p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenitiesPreference");

            migrationBuilder.DropTable(
                name: "FeaturesPreference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenitiesPreference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amenity1 = table.Column<bool>(type: "bit", nullable: false),
                    Amenity2 = table.Column<bool>(type: "bit", nullable: false),
                    Amenity3 = table.Column<bool>(type: "bit", nullable: false),
                    Amenity4 = table.Column<bool>(type: "bit", nullable: false),
                    Amenity5 = table.Column<bool>(type: "bit", nullable: false),
                    PropertyRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenitiesPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmenitiesPreference_Properties_PropertyRef",
                        column: x => x.PropertyRef,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesPreference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature1 = table.Column<bool>(type: "bit", nullable: false),
                    Feature2 = table.Column<bool>(type: "bit", nullable: false),
                    Feature3 = table.Column<bool>(type: "bit", nullable: false),
                    Feature4 = table.Column<bool>(type: "bit", nullable: false),
                    Feature5 = table.Column<bool>(type: "bit", nullable: false),
                    PropertyRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturesPreference_Properties_PropertyRef",
                        column: x => x.PropertyRef,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenitiesPreference_PropertyRef",
                table: "AmenitiesPreference",
                column: "PropertyRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesPreference_PropertyRef",
                table: "FeaturesPreference",
                column: "PropertyRef",
                unique: true);
        }
    }
}
