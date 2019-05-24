using Microsoft.EntityFrameworkCore.Migrations;

namespace kompiuteriuRinkykla.Migrations
{
    public partial class PartTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "CoreCount",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CpuConnType",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "DataStorageInterface",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EfficiencyRating",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxDataStorageLength",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxGpuLength",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxMotherboardLength",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxPsuLength",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MaxRam",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemoryGb",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonitorSocketCount",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PciSocketCount",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ProcessorFrequency",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RamConnType",
                table: "Part",
                nullable: true,
                maxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "RamSocketCount",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Part",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "CoreCount",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "CpuConnType",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "DataStorageInterface",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "EfficiencyRating",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MaxDataStorageLength",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MaxGpuLength",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MaxMotherboardLength",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MaxPsuLength",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MaxRam",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MemoryGb",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MonitorSocketCount",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PciSocketCount",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ProcessorFrequency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "RamConnType",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "RamSocketCount",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Part");
        }
    }
}
