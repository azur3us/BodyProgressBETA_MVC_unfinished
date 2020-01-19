using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodyProgress.Migrations
{
    public partial class UpdataExerciseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartOfBodyId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises",
                column: "PartOfBodyId",
                principalTable: "PartOfBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartOfBodyId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_PartOfBodies_PartOfBodyId",
                table: "Exercises",
                column: "PartOfBodyId",
                principalTable: "PartOfBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
