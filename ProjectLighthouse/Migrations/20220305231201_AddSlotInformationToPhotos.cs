using LBPUnion.ProjectLighthouse;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220305231201_AddSlotInformationToPhotos")]
    public partial class AddSlotInformationToPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SlotType",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SlotType",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_SlotId",
                table: "Photos",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_SlotId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "SlotType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "SlotType",
                table: "Comments");
        }
    }
}
