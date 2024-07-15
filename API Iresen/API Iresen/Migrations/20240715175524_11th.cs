using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class _11th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseNote",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "GlobalNote",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "IsEvaluated",
                table: "Submissions");

            migrationBuilder.CreateTable(
                name: "EvaluationNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmissionId = table.Column<int>(type: "integer", nullable: false),
                    EvaluatorId = table.Column<int>(type: "integer", nullable: false),
                    BaseNote = table.Column<int>(type: "integer", nullable: false),
                    GlobalNote = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationNotes_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationNotes_Users_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationNoteCriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvaluationNoteId = table.Column<int>(type: "integer", nullable: false),
                    CriterionId = table.Column<int>(type: "integer", nullable: false),
                    CriterionName = table.Column<string>(type: "text", nullable: false),
                    BaseDeNotation = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationNoteCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationNoteCriteria_EvaluationNotes_EvaluationNoteId",
                        column: x => x.EvaluationNoteId,
                        principalTable: "EvaluationNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationNoteCriteria_EvaluationNoteId",
                table: "EvaluationNoteCriteria",
                column: "EvaluationNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationNotes_EvaluatorId",
                table: "EvaluationNotes",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationNotes_SubmissionId",
                table: "EvaluationNotes",
                column: "SubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationNoteCriteria");

            migrationBuilder.DropTable(
                name: "EvaluationNotes");

            migrationBuilder.AddColumn<int>(
                name: "BaseNote",
                table: "Submissions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Submissions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlobalNote",
                table: "Submissions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEvaluated",
                table: "Submissions",
                type: "boolean",
                nullable: true);
        }
    }
}
