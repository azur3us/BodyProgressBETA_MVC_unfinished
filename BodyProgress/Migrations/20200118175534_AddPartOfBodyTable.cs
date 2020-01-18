using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodyProgress.Migrations
{
    public partial class AddPartOfBodyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PartOfBodyId",
                table: "Exercises",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartOfBodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfBodies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_PartOfBodyId",
                table: "Exercises",
                column: "PartOfBodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises",
                column: "PartOfBodyId",
                principalTable: "PartOfBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "PartOfBodies");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_PartOfBodyId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PartOfBodyId",
                table: "Exercises");
        }
    }
}
