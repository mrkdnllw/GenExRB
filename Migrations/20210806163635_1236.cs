using Microsoft.EntityFrameworkCore.Migrations;

namespace GenExRB.Migrations
{
    public partial class _1236 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: true),
                    FloorArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToiletAndBath = table.Column<bool>(type: "bit", nullable: false),
                    CarPark = table.Column<bool>(type: "bit", nullable: true),
                    Category1 = table.Column<int>(type: "int", nullable: false),
                    Category2 = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category3 = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<int>(type: "int", nullable: true),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brgy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Properties_PropertyRef",
                        column: x => x.PropertyRef,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Properties_PropertyId",
                        column: x => x.PropertyId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Location_PropertyRef",
                table: "Location",
                column: "PropertyRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PropertyId",
                table: "Photos",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenitiesPreference");

            migrationBuilder.DropTable(
                name: "FeaturesPreference");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
