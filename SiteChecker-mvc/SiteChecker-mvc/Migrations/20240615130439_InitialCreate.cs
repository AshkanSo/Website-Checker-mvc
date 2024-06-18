using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiteChecker_mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    PK_PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PK_PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "WebSites",
                columns: table => new
                {
                    PK_WebSite = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ServerStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSites", x => x.PK_WebSite);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    PK_ErrorLogs = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ErrorCode = table.Column<string>(type: "TEXT", nullable: false),
                    StartOfError = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndOfError = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FK_WebSiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    WebSitePK_WebSite = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.PK_ErrorLogs);
                    table.ForeignKey(
                        name: "FK_ErrorLogs_WebSites_WebSitePK_WebSite",
                        column: x => x.WebSitePK_WebSite,
                        principalTable: "WebSites",
                        principalColumn: "PK_WebSite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbersWebSites",
                columns: table => new
                {
                    PhoneNumbersPK_PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    WebSitesCollectionPK_WebSite = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbersWebSites", x => new { x.PhoneNumbersPK_PhoneNumber, x.WebSitesCollectionPK_WebSite });
                    table.ForeignKey(
                        name: "FK_PhoneNumbersWebSites_PhoneNumbers_PhoneNumbersPK_PhoneNumber",
                        column: x => x.PhoneNumbersPK_PhoneNumber,
                        principalTable: "PhoneNumbers",
                        principalColumn: "PK_PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbersWebSites_WebSites_WebSitesCollectionPK_WebSite",
                        column: x => x.WebSitesCollectionPK_WebSite,
                        principalTable: "WebSites",
                        principalColumn: "PK_WebSite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "PK_PhoneNumber", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "User1", "123456" },
                    { 2, "Contact1", "987654" }
                });

            migrationBuilder.InsertData(
                table: "WebSites",
                columns: new[] { "PK_WebSite", "Name", "ServerStatus", "Url" },
                values: new object[,]
                {
                    { 1, "Fadia", true, "https://fadiashop.com/wakeup" },
                    { 2, "Varzesh3", true, "https://www.varzesh3.com/livescore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_WebSitePK_WebSite",
                table: "ErrorLogs",
                column: "WebSitePK_WebSite");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbersWebSites_WebSitesCollectionPK_WebSite",
                table: "PhoneNumbersWebSites",
                column: "WebSitesCollectionPK_WebSite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "PhoneNumbersWebSites");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "WebSites");
        }
    }
}
