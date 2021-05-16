using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Business_Cards_Web_API.Migrations
{
    public partial class BusinessCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCard", x => x.Id);
                });

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCard");
        }
    }
}
