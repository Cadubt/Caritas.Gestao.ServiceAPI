using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.Gestao.ServiceAPI.Migrations
{
    public partial class ScheduleSheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleSheets",
                schema: "shelt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shelteredName = table.Column<string>(nullable: true),
                    shelteredAge = table.Column<int>(nullable: false),
                    shelteredPhone = table.Column<string>(nullable: true),
                    shelteredAddress = table.Column<string>(nullable: true),
                    responsibleName = table.Column<string>(nullable: false),
                    kinshipId = table.Column<int>(nullable: false),
                    responsiblePhone = table.Column<string>(nullable: false),
                    responsibleAddress = table.Column<string>(nullable: false),
                    interviewDate = table.Column<DateTime>(nullable: false),
                    scheduleDate = table.Column<DateTime>(nullable: false),
                    observation = table.Column<string>(nullable: true),
                    scheduleResponsible = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSheets", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleSheets",
                schema: "shelt");
        }
    }
}
