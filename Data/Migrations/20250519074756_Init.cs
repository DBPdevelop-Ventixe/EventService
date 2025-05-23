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
                values: new object[] { "1", 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ginger Day: A Celebration of Redheads in the Netherlands\r\n\r\nGinger Day is an extraordinary annual event held in the Netherlands. It is dedicated entirely to people with natural red hair. Known for its joyful spirit and sense of belonging, this event attracts thousands of visitors from around the world. It takes place in the city of Tilburg. Previously it was hosted in Breda. The festival has become a beloved tradition among redheads and redhead enthusiasts alike.\r\n\r\nThe celebration began in 2005. It started as a small artistic project by Dutch painter Bart Rouwenhorst. He was searching for a few redheaded models for his paintings. Instead of a handful of participants, he received over a hundred responses. Surprised by the overwhelming interest, he decided to organize a larger gathering. That spontaneous idea became the first official Ginger Day. Since then, the event has grown significantly. It now welcomes thousands of red-haired visitors each year.\r\n\r\nGinger Day usually takes place in late August or early September. The festival spans an entire weekend. It is free of charge and open to people of all ages. The focus is on community, art, and the unique identity of red-haired individuals. The program includes various activities. There are art exhibitions. There are lectures on genetics and red hair. There are fashion shows. There are pub quizzes. There are musical performances. And there are creative workshops.\r\n\r\nOne of the most iconic moments is the group photo. Hundreds of redheads gather in a public square for a massive photograph. This tradition has become a symbol of unity and pride within the ginger community. It often draws international media attention.\r\n\r\nGinger Day also serves as a platform to challenge stereotypes. It aims to celebrate diversity. It encourages self-confidence among people with red hair. Many participants describe the event as life-changing. It gives them a feeling of acceptance. It gives them a sense of connection. It reminds them they are not alone.\r\n\r\nPeople travel from all over the globe to attend. Visitors come from the United Kingdom. From the United States. From Germany. From Italy. From Australia. And many other countries. The festival has inspired similar events in other parts of the world. But the original Dutch Ginger Day remains the largest and most influential.\r\n\r\nIn summary. Ginger Day in the Netherlands is more than just a festival. It is a tribute to a rare genetic trait. It is a celebration of identity and inclusion. It is a vibrant gathering filled with art. With music. With knowledge. And with shared experiences. It is one of the most colorful and welcoming festivals in Europe. A must-visit for anyone with red hair or a love for unique cultural events.", new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-photo/redhead-days-festival-netherlands_951220-116110.jpg", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ginger Festival", "Active" });

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
