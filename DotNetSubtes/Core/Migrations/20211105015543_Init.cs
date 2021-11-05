using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivePeriodStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivePeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndActivePeriodStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndActivePeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}
