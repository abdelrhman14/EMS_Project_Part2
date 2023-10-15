using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_system.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Sector_Investors_Sector_Investor_Id",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Sector_Presenters_Sector_Presenter_Id",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Sector_Presenter_Id",
                table: "Bookings",
                newName: "Presenter_Id");

            migrationBuilder.RenameColumn(
                name: "Sector_Investor_Id",
                table: "Bookings",
                newName: "Investor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_Sector_Presenter_Id",
                table: "Bookings",
                newName: "IX_Bookings_Presenter_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_Sector_Investor_Id",
                table: "Bookings",
                newName: "IX_Bookings_Investor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Investors_Investor_Id",
                table: "Bookings",
                column: "Investor_Id",
                principalTable: "Investors",
                principalColumn: "Investor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Presenters_Presenter_Id",
                table: "Bookings",
                column: "Presenter_Id",
                principalTable: "Presenters",
                principalColumn: "Presenter_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Investors_Investor_Id",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Presenters_Presenter_Id",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Presenter_Id",
                table: "Bookings",
                newName: "Sector_Presenter_Id");

            migrationBuilder.RenameColumn(
                name: "Investor_Id",
                table: "Bookings",
                newName: "Sector_Investor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_Presenter_Id",
                table: "Bookings",
                newName: "IX_Bookings_Sector_Presenter_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_Investor_Id",
                table: "Bookings",
                newName: "IX_Bookings_Sector_Investor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Sector_Investors_Sector_Investor_Id",
                table: "Bookings",
                column: "Sector_Investor_Id",
                principalTable: "Sector_Investors",
                principalColumn: "Sector_Investor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Sector_Presenters_Sector_Presenter_Id",
                table: "Bookings",
                column: "Sector_Presenter_Id",
                principalTable: "Sector_Presenters",
                principalColumn: "Sector_Presenter_Id");
        }
    }
}
