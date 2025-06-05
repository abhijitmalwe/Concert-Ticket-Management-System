using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertTicketManagementSystem.Infrastructure.DbPersistence.Migrations
{
    /// <inheritdoc />
    public partial class cascadefixeswithconstraintsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "TicketTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_EventId1",
                table: "TicketTypes",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Events_EventId1",
                table: "TicketTypes",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Events_EventId1",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_EventId1",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "TicketTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
