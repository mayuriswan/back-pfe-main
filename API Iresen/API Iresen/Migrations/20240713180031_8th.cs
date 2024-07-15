using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class _8th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCriterion_Evaluations_EvaluationId",
                table: "EvaluationCriterion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationCriterion",
                table: "EvaluationCriterion");

            migrationBuilder.RenameTable(
                name: "EvaluationCriterion",
                newName: "EvaluationCriteria");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationCriterion_EvaluationId",
                table: "EvaluationCriteria",
                newName: "IX_EvaluationCriteria_EvaluationId");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId1",
                table: "EvaluationCriteria",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationCriteria",
                table: "EvaluationCriteria",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriteria_EvaluationId1",
                table: "EvaluationCriteria",
                column: "EvaluationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCriteria_Evaluations_EvaluationId",
                table: "EvaluationCriteria",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCriteria_Evaluations_EvaluationId1",
                table: "EvaluationCriteria",
                column: "EvaluationId1",
                principalTable: "Evaluations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCriteria_Evaluations_EvaluationId",
                table: "EvaluationCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCriteria_Evaluations_EvaluationId1",
                table: "EvaluationCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationCriteria",
                table: "EvaluationCriteria");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationCriteria_EvaluationId1",
                table: "EvaluationCriteria");

            migrationBuilder.DropColumn(
                name: "EvaluationId1",
                table: "EvaluationCriteria");

            migrationBuilder.RenameTable(
                name: "EvaluationCriteria",
                newName: "EvaluationCriterion");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationCriteria_EvaluationId",
                table: "EvaluationCriterion",
                newName: "IX_EvaluationCriterion_EvaluationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationCriterion",
                table: "EvaluationCriterion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCriterion_Evaluations_EvaluationId",
                table: "EvaluationCriterion",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
