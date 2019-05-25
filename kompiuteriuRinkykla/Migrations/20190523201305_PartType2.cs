using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class PartType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('data_storage', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('ram', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('processor', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('computer_case', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('motherboard', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('gpu', GETDATE(), GETDATE())");
            migrationBuilder.Sql("INSERT INTO PartType(Name, DateCreated, DateModified) Values('psu', GETDATE(), GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PartType WHERE Name IN ('data_storage', 'ram', 'processor', 'computer_case', 'motherboard', 'gpu', 'psu')");
        }
    }
}
