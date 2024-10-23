using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsNew.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddedChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features");

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features");

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Announcements_AnnouncementId",
                table: "Features",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
