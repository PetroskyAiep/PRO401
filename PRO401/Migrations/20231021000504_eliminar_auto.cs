using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRO401.Migrations
{
    /// <inheritdoc />
    public partial class eliminar_auto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroceriaId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });
        }
    }
}
