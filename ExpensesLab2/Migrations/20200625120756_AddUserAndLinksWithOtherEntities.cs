using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesLab2.Migrations
{
    public partial class AddUserAndLinksWithOtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Expenses_ExpenseId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ExpenseId",
                table: "Comment",
                newName: "IX_Comment_ExpenseId");

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AddedById",
                table: "Expenses",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AddedById",
                table: "Comment",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_AddedById",
                table: "Comment",
                column: "AddedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Expenses_ExpenseId",
                table: "Comment",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_User_AddedById",
                table: "Expenses",
                column: "AddedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_AddedById",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Expenses_ExpenseId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_User_AddedById",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AddedById",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AddedById",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ExpenseId",
                table: "Comments",
                newName: "IX_Comments_ExpenseId");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseId",
                table: "Comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Expenses_ExpenseId",
                table: "Comments",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
