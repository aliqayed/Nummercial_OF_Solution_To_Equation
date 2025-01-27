using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nummercial_finalProject.Migrations
{
    /// <inheritdoc />
    public partial class e1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemRViewModelController");

            migrationBuilder.CreateTable(
                name: "ProblemsR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialValue = table.Column<double>(type: "float", nullable: false),
                    LastValue = table.Column<double>(type: "float", nullable: false),
                    Y0 = table.Column<double>(type: "float", nullable: false),
                    N = table.Column<int>(type: "int", nullable: false),
                    H = table.Column<double>(type: "float", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ResultIdR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemsR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemsR_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    y = table.Column<double>(type: "float", nullable: false),
                    ProblemRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultR_ProblemsR_ProblemRId",
                        column: x => x.ProblemRId,
                        principalTable: "ProblemsR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemsR_PersonId",
                table: "ProblemsR",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemsR_ResultIdR",
                table: "ProblemsR",
                column: "ResultIdR");

            migrationBuilder.CreateIndex(
                name: "IX_ResultR_ProblemRId",
                table: "ResultR",
                column: "ProblemRId",
                unique: true,
                filter: "[ProblemRId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultR");

            migrationBuilder.DropTable(
                name: "ProblemsR");

            migrationBuilder.CreateTable(
                name: "ProblemRViewModelController",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: true),
                    H = table.Column<double>(type: "float", nullable: false),
                    InitialValue = table.Column<double>(type: "float", nullable: false),
                    LastValue = table.Column<double>(type: "float", nullable: false),
                    N = table.Column<int>(type: "int", nullable: false),
                    NameFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Y0 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemRViewModelController", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemRViewModelController_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProblemRViewModelController_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemRViewModelController_PersonId",
                table: "ProblemRViewModelController",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemRViewModelController_ResultId",
                table: "ProblemRViewModelController",
                column: "ResultId");
        }
    }
}
