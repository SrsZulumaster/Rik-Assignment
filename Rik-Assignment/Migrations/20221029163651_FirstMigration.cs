using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rik_Assignment.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyParticipantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ParticipantAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    EventIDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParticipantModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyParticipantModel_EventModel_EventIDId",
                        column: x => x.EventIDId,
                        principalTable: "EventModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalID = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    EventIDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantModel_EventModel_EventIDId",
                        column: x => x.EventIDId,
                        principalTable: "EventModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParticipantModel_EventIDId",
                table: "CompanyParticipantModel",
                column: "EventIDId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantModel_EventIDId",
                table: "ParticipantModel",
                column: "EventIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyParticipantModel");

            migrationBuilder.DropTable(
                name: "ParticipantModel");

            migrationBuilder.DropTable(
                name: "EventModel");
        }
    }
}
