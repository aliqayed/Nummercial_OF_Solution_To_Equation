using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nummercial_finalProject.Migrations
{
    /// <inheritdoc />
    public partial class e0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProblemRViewModelController",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N = table.Column<int>(type: "int", nullable: false),
                    NameFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialValue = table.Column<double>(type: "float", nullable: false),
                    LastValue = table.Column<double>(type: "float", nullable: false),
                    Y0 = table.Column<double>(type: "float", nullable: false),
                    H = table.Column<double>(type: "float", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemRViewModelController");
        }
    }
}
