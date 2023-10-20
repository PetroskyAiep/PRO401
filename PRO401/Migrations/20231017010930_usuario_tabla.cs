using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRO401.Migrations
{
    /// <inheritdoc />
    public partial class usuario_tabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComunaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false, 
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComunaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "AspNetUsers");
        }
    }
}
