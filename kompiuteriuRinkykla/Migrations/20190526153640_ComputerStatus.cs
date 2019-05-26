using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class ComputerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Computer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Computer",
                defaultValue: "completed",
                maxLength: 255,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Computer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Computer",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
