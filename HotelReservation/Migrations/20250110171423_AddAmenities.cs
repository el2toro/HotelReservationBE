using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Location",
                newName: "ZipCode");

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PricePerNight",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasInternet = table.Column<bool>(type: "bit", nullable: false),
                    HasPrivateParking = table.Column<bool>(type: "bit", nullable: false),
                    HasRoomService = table.Column<bool>(type: "bit", nullable: false),
                    HasFrontDesck24 = table.Column<bool>(type: "bit", nullable: false),
                    HasFitenssCenter = table.Column<bool>(type: "bit", nullable: false),
                    HasSPA = table.Column<bool>(type: "bit", nullable: false),
                    HasNetflix = table.Column<bool>(type: "bit", nullable: false),
                    HasSmokingArea = table.Column<bool>(type: "bit", nullable: false),
                    HasNoSmokingRooms = table.Column<bool>(type: "bit", nullable: false),
                    HasGameRoom = table.Column<bool>(type: "bit", nullable: false),
                    HasPoolParkour = table.Column<bool>(type: "bit", nullable: false),
                    HasVideoGames = table.Column<bool>(type: "bit", nullable: false),
                    HasRestaurant = table.Column<bool>(type: "bit", nullable: false),
                    HasBbq = table.Column<bool>(type: "bit", nullable: false),
                    HasSaturdayNight = table.Column<bool>(type: "bit", nullable: false),
                    HasSwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    HasCurencyExcenge = table.Column<bool>(type: "bit", nullable: false),
                    HasLounge = table.Column<bool>(type: "bit", nullable: false),
                    HasMiniBar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AmenitiesId",
                table: "Hotels",
                column: "AmenitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Amenities_AmenitiesId",
                table: "Hotels",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Amenities_AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Location",
                newName: "PostCode");
        }
    }
}
