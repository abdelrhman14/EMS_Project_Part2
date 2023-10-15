using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_system.Migrations
{
    /// <inheritdoc />
    public partial class Ikqbe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_Hotel_Id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Hotel_Id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Hotel_Id",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hotel_Id",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Hotel_Id",
                table: "Bookings",
                column: "Hotel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_Hotel_Id",
                table: "Bookings",
                column: "Hotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id");
        }
    }
}
