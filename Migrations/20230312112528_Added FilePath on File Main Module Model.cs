using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Migrations
{
    public partial class AddedFilePathonFileMainModuleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainModules",
                columns: table => new
                {
                    MainModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainModuleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MainModuleVersion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ModuleImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainModules", x => x.MainModuleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainModules");
        }
    }
}
