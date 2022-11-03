using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class departement_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Departements_DivisionId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_DivisionId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Divisions");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_DivisionId",
                table: "Departements",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departements_Divisions_DivisionId",
                table: "Departements",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departements_Divisions_DivisionId",
                table: "Departements");

            migrationBuilder.DropIndex(
                name: "IX_Departements_DivisionId",
                table: "Departements");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Divisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DivisionId",
                table: "Divisions",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Departements_DivisionId",
                table: "Divisions",
                column: "DivisionId",
                principalTable: "Departements",
                principalColumn: "Id");
        }
    }
}
