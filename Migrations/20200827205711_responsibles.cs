using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.Gestao.ServiceAPI.Migrations
{
    public partial class responsibles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsibles",
                schema: "shelt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    responsibleName = table.Column<string>(nullable: true),
                    adress = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    kinshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsibles",
                schema: "shelt");
        }
    }
}
