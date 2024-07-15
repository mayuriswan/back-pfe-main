using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ReviewForm_ReviewFormId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectEvaluators");

            migrationBuilder.DropTable(
                name: "ReviewCriteria");

            migrationBuilder.DropTable(
                name: "ReviewForm");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "EvaluatorIds",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "ReviewFormId",
                table: "Projects",
                newName: "EvaluationFormId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ReviewFormId",
                table: "Projects",
                newName: "IX_Projects_EvaluationFormId");

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    EvaluatorsId = table.Column<int>(type: "integer", nullable: false),
                    ProjectsToEvaluateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.EvaluatorsId, x.ProjectsToEvaluateId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsToEvaluateId",
                        column: x => x.ProjectsToEvaluateId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_EvaluatorsId",
                        column: x => x.EvaluatorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectsToEvaluateId",
                table: "ProjectUser",
                column: "ProjectsToEvaluateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_EvaluationForms_EvaluationFormId",
                table: "Projects",
                column: "EvaluationFormId",
                principalTable: "EvaluationForms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_EvaluationForms_EvaluationFormId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "EvaluationFormId",
                table: "Projects",
                newName: "ReviewFormId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_EvaluationFormId",
                table: "Projects",
                newName: "IX_Projects_ReviewFormId");

            migrationBuilder.AddColumn<List<int>>(
                name: "EvaluatorIds",
                table: "Evaluations",
                type: "integer[]",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "ProjectEvaluators",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEvaluators", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectEvaluator_Project",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectEvaluator_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    ReviewerId = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewCriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MaxScore = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReviewFormId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewCriteria_ReviewForm_ReviewFormId",
                        column: x => x.ReviewFormId,
                        principalTable: "ReviewForm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewCriteria_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEvaluators_UserId",
                table: "ProjectEvaluators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewCriteria_ReviewFormId",
                table: "ReviewCriteria",
                column: "ReviewFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewCriteria_ReviewId",
                table: "ReviewCriteria",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProjectId",
                table: "Reviews",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ReviewForm_ReviewFormId",
                table: "Projects",
                column: "ReviewFormId",
                principalTable: "ReviewForm",
                principalColumn: "Id");
        }
    }
}
