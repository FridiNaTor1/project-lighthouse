using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    public partial class AddInternalSlotIdToSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartedLevels_Slots_SlotId",
                table: "HeartedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedLevels_Slots_SlotId",
                table: "QueuedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_RatedLevels_Slots_SlotId",
                table: "RatedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Slots_SlotId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Slots_SlotId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedLevels_Slots_SlotId",
                table: "VisitedLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.AlterColumn<int>(
                name: "SlotId",
                table: "Slots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "InternalSlotId",
                table: "Slots",
                type: "int",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "InternalSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartedLevels_Slots_SlotId",
                table: "HeartedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedLevels_Slots_SlotId",
                table: "QueuedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatedLevels_Slots_SlotId",
                table: "RatedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Slots_SlotId",
                table: "Reviews",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Slots_SlotId",
                table: "Scores",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedLevels_Slots_SlotId",
                table: "VisitedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "InternalSlotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartedLevels_Slots_SlotId",
                table: "HeartedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedLevels_Slots_SlotId",
                table: "QueuedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_RatedLevels_Slots_SlotId",
                table: "RatedLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Slots_SlotId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Slots_SlotId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedLevels_Slots_SlotId",
                table: "VisitedLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "InternalSlotId",
                table: "Slots");

            migrationBuilder.AlterColumn<int>(
                name: "SlotId",
                table: "Slots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartedLevels_Slots_SlotId",
                table: "HeartedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Slots_SlotId",
                table: "Photos",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedLevels_Slots_SlotId",
                table: "QueuedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatedLevels_Slots_SlotId",
                table: "RatedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Slots_SlotId",
                table: "Reviews",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Slots_SlotId",
                table: "Scores",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedLevels_Slots_SlotId",
                table: "VisitedLevels",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
