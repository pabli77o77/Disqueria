using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disqueria.Migrations
{
    public partial class disqueria_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artista = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaID);
                });

            migrationBuilder.CreateTable(
                name: "Discograficas",
                columns: table => new
                {
                    DiscograficaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discografica = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discograficas", x => x.DiscograficaID);
                });

            migrationBuilder.CreateTable(
                name: "DiscoVM",
                columns: table => new
                {
                    DiscoID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    Artista = table.Column<string>(nullable: true),
                    ArtistaID = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true),
                    GeneroID = table.Column<int>(nullable: false),
                    Discografica = table.Column<string>(nullable: true),
                    DiscograficaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoVM", x => new { x.DiscoID, x.Titulo });
                    table.UniqueConstraint("AK_DiscoVM_DiscoID", x => x.DiscoID);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    EntidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoEntidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.EntidadID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genero = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    DiscoID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    ArtistaID = table.Column<int>(nullable: false),
                    GeneroID = table.Column<int>(nullable: false),
                    DiscograficaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => new { x.DiscoID, x.Titulo });
                    table.UniqueConstraint("AK_Discos_DiscoID", x => x.DiscoID);
                    table.ForeignKey(
                        name: "FK_Discos_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artistas",
                        principalColumn: "ArtistaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discos_Discograficas_DiscograficaID",
                        column: x => x.DiscograficaID,
                        principalTable: "Discograficas",
                        principalColumn: "DiscograficaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discos_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discos_ArtistaID",
                table: "Discos",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_DiscograficaID",
                table: "Discos",
                column: "DiscograficaID");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_GeneroID",
                table: "Discos",
                column: "GeneroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "DiscoVM");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Discograficas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
