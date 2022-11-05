using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rik_Assignment.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "ParticipantModel",
                newName: "EventRefID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantModel_EventRefID",
                table: "ParticipantModel",
                column: "EventRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantModel_EventModel_EventRefID",
                table: "ParticipantModel",
                column: "EventRefID",
                principalTable: "EventModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantModel_EventModel_EventRefID",
                table: "ParticipantModel");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantModel_EventRefID",
                table: "ParticipantModel");

            migrationBuilder.RenameColumn(
                name: "EventRefID",
                table: "ParticipantModel",
                newName: "EventID");
        }
    }
}
