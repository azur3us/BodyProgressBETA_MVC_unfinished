using Microsoft.EntityFrameworkCore.Migrations;

namespace BodyProgress.Migrations
{
    public partial class AddTrainingPlanName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingPlanName",
                table: "TrainingPlans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingPlanName",
                table: "TrainingPlans");
        }
    }
}
