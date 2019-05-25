using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class PartType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartTypeId",
                table: "Part",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "PartType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false, maxLength: 255)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartTypeId",
                table: "Part",
                column: "PartTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part",
                column: "PartTypeId",
                principalTable: "PartType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_PartType_PartTypeId",
                table: "Part");

            migrationBuilder.DropTable(
                name: "PartType");

            migrationBuilder.DropIndex(
                name: "IX_Part_PartTypeId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PartTypeId",
                table: "Part");
        }
    }
}
