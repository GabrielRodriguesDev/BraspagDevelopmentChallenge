using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentChallenge.Database.Migrations
{
    public partial class VR01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MDRs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Adquirente = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Bandeira = table.Column<string>(type: "TEXT", nullable: false),
                    Credito = table.Column<double>(type: "REAL", nullable: false),
                    Debito = table.Column<double>(type: "REAL", nullable: false),
                    MDRId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxas_MDRs_MDRId",
                        column: x => x.MDRId,
                        principalTable: "MDRs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxas_MDRId",
                table: "Taxas",
                column: "MDRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxas");

            migrationBuilder.DropTable(
                name: "MDRs");
        }
    }
}
