using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatingBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketsAmount = table.Column<int>(type: "int", nullable: false),
                    TicketsSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventPackages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPackages_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSponsors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SponsorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSponsors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CreateDate", "Description", "EventDate", "ImageUrl", "ModifiedDate", "Name", "Status" },
                values: new object[] { "1", 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The festival takes place in the last full weekend of August, so the next edition will be August 29-31 2025. The most important festival day is Sunday August 31 2025, when we take the famous group photo. Location: A lot of the activities will take place in Spoorpark, Tilburg, which is also where the campsite is located.", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-photo/redhead-days-festival-netherlands_951220-116110.jpg", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ginger Festival", "Active" });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Price", "SeatingBenefits", "TicketsAmount", "TicketsSold", "Title" },
                values: new object[,]
                {
                    { "1", 35m, "[\"Standing, Access to Festival Grounds\"]", 1000, 874, "General Package" },
                    { "2", 55m, "[\"Seated, Prime View\"]", 750, 555, "Gold Package" },
                    { "3", 90m, "[\"Seated, Front-row View\"]", 300, 121, "Diamond Package" },
                    { "4", 175m, "[\"Seated, Exclusive Lounge\"]", 150, 34, "VIP Package" },
                    { "5", 350m, "[\"Seated, Exclusive Lounge, Meet \\u0026 Greet, Backstage Access\"]", 75, 25, "Ultimate VIP Package" }
                });

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id", "LogoUrl", "Title" },
                values: new object[,]
                {
                    { "1", "../images/sponsors/Logo ipsum-1.svg", "Ipsum 1" },
                    { "2", "../images/sponsors/Logo ipsum-2.svg", "Ipsum 2" },
                    { "3", "../images/sponsors/Logo ipsum-3.svg", "Ipsum 3" },
                    { "4", "../images/sponsors/Logo ipsum-4.svg", "Ipsum 4" },
                    { "5", "../images/sponsors/Logo ipsum-5.svg", "Ipsum 5" },
                    { "6", "../images/sponsors/Logo ipsum-6.svg", "Ipsum 6" },
                    { "7", "../images/sponsors/Logo ipsum-7.svg", "Ipsum 7" },
                    { "8", "../images/sponsors/Logo ipsum-8.svg", "Ipsum 8" }
                });

            migrationBuilder.InsertData(
                table: "EventPackages",
                columns: new[] { "Id", "EventId", "PackageId" },
                values: new object[,]
                {
                    { "1", "1", "1" },
                    { "2", "1", "2" },
                    { "3", "1", "3" },
                    { "4", "1", "4" },
                    { "5", "1", "5" }
                });

            migrationBuilder.InsertData(
                table: "EventSponsors",
                columns: new[] { "Id", "EventId", "SponsorId" },
                values: new object[,]
                {
                    { "1", "1", "1" },
                    { "2", "1", "2" },
                    { "3", "1", "3" },
                    { "4", "1", "4" },
                    { "5", "1", "5" },
                    { "6", "1", "6" },
                    { "7", "1", "7" },
                    { "8", "1", "8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPackages_EventId",
                table: "EventPackages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPackages_PackageId",
                table: "EventPackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsors_EventId",
                table: "EventSponsors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsors_SponsorId",
                table: "EventSponsors",
                column: "SponsorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPackages");

            migrationBuilder.DropTable(
                name: "EventSponsors");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Sponsors");
        }
    }
}
