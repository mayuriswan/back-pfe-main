using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class _9th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_ProjectId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Evaluations");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EvaluationId",
                table: "Projects",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Evaluations_EvaluationId",
                table: "Projects",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Evaluations_EvaluationId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EvaluationId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Evaluations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ProjectId",
                table: "Evaluations",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
