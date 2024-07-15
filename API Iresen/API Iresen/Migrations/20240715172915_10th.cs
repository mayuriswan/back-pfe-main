using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class _10th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
