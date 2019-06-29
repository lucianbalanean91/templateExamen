using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace templateExamen.Migrations
{
    public partial class tablePachetAndUniqueCodTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pachets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaraOrigine = table.Column<string>(nullable: true),
                    DenumireExpeditor = table.Column<string>(nullable: true),
                    TaraDestinatie = table.Column<string>(nullable: true),
                    DenumireDestinatar = table.Column<string>(nullable: true),
                    AdresaDestinatar = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    CodTracking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pachets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pachets_CodTracking",
                table: "Pachets",
                column: "CodTracking",
                unique: true,
                filter: "[CodTracking] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pachets");
        }
    }
}
