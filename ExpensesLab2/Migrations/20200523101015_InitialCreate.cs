using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesLab2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Sum = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    TypeOfExpense = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
