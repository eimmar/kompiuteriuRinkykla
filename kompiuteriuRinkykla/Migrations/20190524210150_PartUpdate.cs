using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class PartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataStorageInterface",
                table: "Part",
                nullable: true,
                maxLength: 255,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataStorageInterface",
                table: "Part",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
