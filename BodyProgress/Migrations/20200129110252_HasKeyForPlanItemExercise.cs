using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodyProgress.Migrations
{
    public partial class HasKeyForPlanItemExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanItemExercises",
                table: "PlanItemExercises");

            migrationBuilder.DropIndex(
                name: "IX_PlanItemExercises_ExerciseId",
                table: "PlanItemExercises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlanItemExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanItemExercises",
                table: "PlanItemExercises",
                columns: new[] { "ExerciseId", "PlanItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanItemExercises",
                table: "PlanItemExercises");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PlanItemExercises",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanItemExercises",
                table: "PlanItemExercises",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanItemExercises_ExerciseId",
                table: "PlanItemExercises",
                column: "ExerciseId");
        }
    }
}
