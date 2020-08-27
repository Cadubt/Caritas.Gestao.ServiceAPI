using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.Gestao.ServiceAPI.Migrations
{
    public partial class Sheltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                schema: "shelt",
                name: "Sheltereds",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: true),
                    birthDate = table.Column<DateTime>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    bloodTyping = table.Column<int>(nullable: true),
                    entryDate = table.Column<DateTime>(nullable: false),
                    perfilImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheltereds", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                schema: "shelt",
                name: "Sheltereds");
        }
    }
}
