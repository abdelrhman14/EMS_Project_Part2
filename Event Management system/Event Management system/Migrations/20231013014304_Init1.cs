using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_system.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Investor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.Investor_Id);
                });

            migrationBuilder.CreateTable(
                name: "Presenters",
                columns: table => new
                {
                    Presenter_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenters", x => x.Presenter_Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchViewModels",
                columns: table => new
                {
                    SearchViewModel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchViewModels", x => x.SearchViewModel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Sector_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Sector_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    SearchViewModel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_SearchViewModels_SearchViewModel_Id",
                        column: x => x.SearchViewModel_Id,
                        principalTable: "SearchViewModels",
                        principalColumn: "SearchViewModel_Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchingViewModel",
                columns: table => new
                {
                    MV_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Investor_Id = table.Column<int>(type: "int", nullable: false),
                    InvestorsInvestor_Id = table.Column<int>(type: "int", nullable: true),
                    Sector_Id = table.Column<int>(type: "int", nullable: false),
                    Sector_Id1 = table.Column<int>(type: "int", nullable: true),
                    Presenter_Id = table.Column<int>(type: "int", nullable: false),
                    PresentersPresenter_Id = table.Column<int>(type: "int", nullable: true),
                    FromDate_Investor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate_Investor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate_Presenter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate_Presenter = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingViewModel", x => x.MV_Id);
                    table.ForeignKey(
                        name: "FK_MatchingViewModel_Investors_InvestorsInvestor_Id",
                        column: x => x.InvestorsInvestor_Id,
                        principalTable: "Investors",
                        principalColumn: "Investor_Id");
                    table.ForeignKey(
                        name: "FK_MatchingViewModel_Presenters_PresentersPresenter_Id",
                        column: x => x.PresentersPresenter_Id,
                        principalTable: "Presenters",
                        principalColumn: "Presenter_Id");
                    table.ForeignKey(
                        name: "FK_MatchingViewModel_Sectors_Sector_Id1",
                        column: x => x.Sector_Id1,
                        principalTable: "Sectors",
                        principalColumn: "Sector_Id");
                });

            migrationBuilder.CreateTable(
                name: "Sector_Investors",
                columns: table => new
                {
                    Sector_Investor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Investor_Id = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sector_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector_Investors", x => x.Sector_Investor_Id);
                    table.ForeignKey(
                        name: "FK_Sector_Investors_Investors_Investor_Id",
                        column: x => x.Investor_Id,
                        principalTable: "Investors",
                        principalColumn: "Investor_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sector_Investors_Sectors_Sector_Id",
                        column: x => x.Sector_Id,
                        principalTable: "Sectors",
                        principalColumn: "Sector_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sector_Presenters",
                columns: table => new
                {
                    Sector_Presenter_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Presenter_Id = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sector_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector_Presenters", x => x.Sector_Presenter_Id);
                    table.ForeignKey(
                        name: "FK_Sector_Presenters_Presenters_Presenter_Id",
                        column: x => x.Presenter_Id,
                        principalTable: "Presenters",
                        principalColumn: "Presenter_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sector_Presenters_Sectors_Sector_Id",
                        column: x => x.Sector_Id,
                        principalTable: "Sectors",
                        principalColumn: "Sector_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector_Investor_Id = table.Column<int>(type: "int", nullable: false),
                    Sector_Presenter_Id = table.Column<int>(type: "int", nullable: false),
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Booking_Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Sector_Investors_Sector_Investor_Id",
                        column: x => x.Sector_Investor_Id,
                        principalTable: "Sector_Investors",
                        principalColumn: "Sector_Investor_Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Sector_Presenters_Sector_Presenter_Id",
                        column: x => x.Sector_Presenter_Id,
                        principalTable: "Sector_Presenters",
                        principalColumn: "Sector_Presenter_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Room_Id",
                table: "Bookings",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Sector_Investor_Id",
                table: "Bookings",
                column: "Sector_Investor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Sector_Presenter_Id",
                table: "Bookings",
                column: "Sector_Presenter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingViewModel_InvestorsInvestor_Id",
                table: "MatchingViewModel",
                column: "InvestorsInvestor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingViewModel_PresentersPresenter_Id",
                table: "MatchingViewModel",
                column: "PresentersPresenter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingViewModel_Sector_Id1",
                table: "MatchingViewModel",
                column: "Sector_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hotel_Id",
                table: "Rooms",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SearchViewModel_Id",
                table: "Rooms",
                column: "SearchViewModel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Investors_Investor_Id",
                table: "Sector_Investors",
                column: "Investor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Investors_Sector_Id",
                table: "Sector_Investors",
                column: "Sector_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Presenters_Presenter_Id",
                table: "Sector_Presenters",
                column: "Presenter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Presenters_Sector_Id",
                table: "Sector_Presenters",
                column: "Sector_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MatchingViewModel");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Sector_Investors");

            migrationBuilder.DropTable(
                name: "Sector_Presenters");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "SearchViewModels");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropTable(
                name: "Presenters");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
