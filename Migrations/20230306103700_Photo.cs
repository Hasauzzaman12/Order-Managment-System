using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageNage",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "GetImages");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GetImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "GetImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetImages",
                table: "GetImages",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GetImages",
                table: "GetImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GetImages");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "GetImages");

            migrationBuilder.RenameTable(
                name: "GetImages",
                newName: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageNage",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");
        }
    }
}
