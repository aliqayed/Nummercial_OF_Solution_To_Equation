using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nummercial_finalProject.Migrations
{
    /// <inheritdoc />
    public partial class e10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultR_ProblemsR_ProblemRId",
                table: "ResultR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultR",
                table: "ResultR");

            migrationBuilder.RenameTable(
                name: "ResultR",
                newName: "ResultRs");

            migrationBuilder.RenameIndex(
                name: "IX_ResultR_ProblemRId",
                table: "ResultRs",
                newName: "IX_ResultRs_ProblemRId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultRs",
                table: "ResultRs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultRs_ProblemsR_ProblemRId",
                table: "ResultRs",
                column: "ProblemRId",
                principalTable: "ProblemsR",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultRs_ProblemsR_ProblemRId",
                table: "ResultRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultRs",
                table: "ResultRs");

            migrationBuilder.RenameTable(
                name: "ResultRs",
                newName: "ResultR");

            migrationBuilder.RenameIndex(
                name: "IX_ResultRs_ProblemRId",
                table: "ResultR",
                newName: "IX_ResultR_ProblemRId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultR",
                table: "ResultR",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultR_ProblemsR_ProblemRId",
                table: "ResultR",
                column: "ProblemRId",
                principalTable: "ProblemsR",
                principalColumn: "Id");
        }
    }
}
