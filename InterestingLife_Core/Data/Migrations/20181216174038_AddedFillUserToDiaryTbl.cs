using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestingLife_Core.Data.Migrations
{
    public partial class AddedFillUserToDiaryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Diaries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_AspNetUsers_UserId",
                table: "Diaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_AspNetUsers_UserId",
                table: "Diaries");

            migrationBuilder.DropIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Diaries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
