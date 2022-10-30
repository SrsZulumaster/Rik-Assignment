using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rik_Assignment.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantModel_EventModel_EventIDId",
                table: "ParticipantModel");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantModel_EventIDId",
                table: "ParticipantModel");

            migrationBuilder.RenameColumn(
                name: "EventIDId",
                table: "ParticipantModel",
                newName: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "ParticipantModel",
                newName: "EventIDId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantModel_EventIDId",
                table: "ParticipantModel",
                column: "EventIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantModel_EventModel_EventIDId",
                table: "ParticipantModel",
                column: "EventIDId",
                principalTable: "EventModel",
                principalColumn: "Id");
        }
    }
}
