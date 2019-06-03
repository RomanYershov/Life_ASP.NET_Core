using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterestingLife_Core.Migrations
{
    public partial class AddCreationDateToSongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Categories_CategoryId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Songs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Songs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Categories_CategoryId",
                table: "Songs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
