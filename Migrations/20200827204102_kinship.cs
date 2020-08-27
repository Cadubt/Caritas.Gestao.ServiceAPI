using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.Gestao.ServiceAPI.Migrations
{
    public partial class kinship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shelt");

            migrationBuilder.EnsureSchema(
                name: "usr");

            migrationBuilder.CreateTable(
                name: "Kinships",
                schema: "shelt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KinName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kinships",
                schema: "shelt");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "usr");
        }
    }
}
