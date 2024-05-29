using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Iresen.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectCall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RespoId = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Instituthote = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Budget = table.Column<int>(type: "integer", nullable: false),
                    Dureemin = table.Column<int>(type: "integer", nullable: false),
                    Duremax = table.Column<int>(type: "integer", nullable: false),
                    Paysautorises = table.Column<List<string>>(type: "text[]", nullable: false),
                    Datepub = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dateclo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Soumissionaccepte = table.Column<int>(type: "integer", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aaps_Users_RespoId",
                        column: x => x.RespoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Responsable = table.Column<string>(type: "text", nullable: false),
                    Categorie = table.Column<string>(type: "text", nullable: false),
                    InstitutHote = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: false),
                    DureeMinimale = table.Column<int>(type: "integer", nullable: false),
                    DureeMaximale = table.Column<int>(type: "integer", nullable: false),
                    TypeTache = table.Column<string>(type: "text", nullable: false),
                    PaysAutorises = table.Column<string>(type: "text", nullable: false),
                    BudgetSepare = table.Column<bool>(type: "boolean", nullable: false),
                    PostBudget = table.Column<string>(type: "text", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCloture = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoumissionAcceptee = table.Column<int>(type: "integer", nullable: false),
                    FormulaireEvaluation = table.Column<string>(type: "text", nullable: false),
                    Documents = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCalls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aaps_RespoId",
                table: "Aaps",
                column: "RespoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aaps");

            migrationBuilder.DropTable(
                name: "ProjectCalls");
        }
    }
}
