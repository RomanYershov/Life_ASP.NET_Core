using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestingLife_Core.Data.Migrations
{
    public partial class AddedFillUserIdToDiaryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Diaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Diaries");
        }
    }
}
