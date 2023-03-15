using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Pictures",
                newName: "ViewName");

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Pictures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Pictures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModuleImageUrl",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModuleSerial",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModuleImageUrl",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModuleSerial",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "ViewName",
                table: "Pictures",
                newName: "Image");
        }
    }
}
