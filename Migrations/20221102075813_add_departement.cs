using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_departement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Divisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Departements_DivisionId",
                table: "Divisions");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_DivisionId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Divisions");
        }
    }
}
