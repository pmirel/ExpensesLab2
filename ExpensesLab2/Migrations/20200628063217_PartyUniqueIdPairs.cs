using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesLab2.Migrations
{
    public partial class PartyUniqueIdPairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shopping = table.Column<string>(nullable: true),
                    totalExpenses = table.Column<decimal>(nullable: false),
                    ExpenseId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Party_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Party_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Party_UserId1",
                table: "Party",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Party_ExpenseId_UserId",
                table: "Party",
                columns: new[] { "ExpenseId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Party");
        }
    }
}
