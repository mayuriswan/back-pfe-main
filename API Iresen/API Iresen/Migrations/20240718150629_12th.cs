using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class _12th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationNoteCriteria_EvaluationNotes_EvaluationNoteId",
                table: "EvaluationNoteCriteria");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Submissions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationNoteId",
                table: "EvaluationNoteCriteria",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationNoteCriteria_EvaluationNotes_EvaluationNoteId",
                table: "EvaluationNoteCriteria",
                column: "EvaluationNoteId",
                principalTable: "EvaluationNotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationNoteCriteria_EvaluationNotes_EvaluationNoteId",
                table: "EvaluationNoteCriteria");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Submissions");

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationNoteId",
                table: "EvaluationNoteCriteria",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationNoteCriteria_EvaluationNotes_EvaluationNoteId",
                table: "EvaluationNoteCriteria",
                column: "EvaluationNoteId",
                principalTable: "EvaluationNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
