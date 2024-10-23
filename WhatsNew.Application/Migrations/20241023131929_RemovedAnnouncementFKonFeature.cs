using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsNew.Application.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAnnouncementFKonFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_AnnouncementId",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Features_AnnouncementId",
                table: "Features",
                column: "AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id");
        }
    }
}
