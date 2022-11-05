using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rik_Assignment.Migrations
{
    public partial class fouthmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyParticipantModel_EventModel_EventIDId",
                table: "CompanyParticipantModel");

            migrationBuilder.RenameColumn(
                name: "EventIDId",
                table: "CompanyParticipantModel",
                newName: "EventRefID");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyParticipantModel_EventIDId",
                table: "CompanyParticipantModel",
                newName: "IX_CompanyParticipantModel_EventRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyParticipantModel_EventModel_EventRefID",
                table: "CompanyParticipantModel",
                column: "EventRefID",
                principalTable: "EventModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyParticipantModel_EventModel_EventRefID",
                table: "CompanyParticipantModel");

            migrationBuilder.RenameColumn(
                name: "EventRefID",
                table: "CompanyParticipantModel",
                newName: "EventIDId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyParticipantModel_EventRefID",
                table: "CompanyParticipantModel",
                newName: "IX_CompanyParticipantModel_EventIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyParticipantModel_EventModel_EventIDId",
                table: "CompanyParticipantModel",
                column: "EventIDId",
                principalTable: "EventModel",
                principalColumn: "Id");
        }
    }
}
