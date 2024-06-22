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
                name: "WebSites",
                columns: table => new
                {
                    PK_WebSite = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ServerStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    Number1 = table.Column<string>(type: "TEXT", nullable: false),
                    Number2 = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.InsertData(
                table: "WebSites",
                columns: new[] { "PK_WebSite", "Name", "Number1", "Number2", "ServerStatus", "Url" },
                values: new object[,]
                {
                    { 1, "Fadia", "091322222", "", true, "https://fadiashop.com/wakeup" },
                    { 2, "Varzesh3", "0913111111", "0912555555", true, "https://www.varzesh3.com/livescore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_WebSitePK_WebSite",
                table: "ErrorLogs",
                column: "WebSitePK_WebSite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "WebSites");
        }
    }
}
