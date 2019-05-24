using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class PartFKUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part");

            migrationBuilder.AlterColumn<int>(
                name: "PartTypeId",
                table: "Part",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part",
                column: "PartTypeId",
                principalTable: "PartType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part");

            migrationBuilder.AlterColumn<int>(
                name: "PartTypeId",
                table: "Part",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part",
                column: "PartTypeId",
                principalTable: "PartType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
