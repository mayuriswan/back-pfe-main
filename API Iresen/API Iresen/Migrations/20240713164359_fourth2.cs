using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class fourth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Evaluations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Evaluations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Projects_ProjectId",
                table: "Evaluations",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
