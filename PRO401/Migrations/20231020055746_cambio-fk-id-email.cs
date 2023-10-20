using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRO401.Migrations
{
    /// <inheritdoc />
    public partial class cambiofkidemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuesta_AspNetUsers_UsuarioId",
                table: "Encuesta");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Encuesta",
                newName: "UsuarioEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Encuesta_UsuarioId",
                table: "Encuesta",
                newName: "IX_Encuesta_UsuarioEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Encuesta_AspNetUsers_UsuarioEmail",
                table: "Encuesta",
                column: "UsuarioEmail",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuesta_AspNetUsers_UsuarioEmail",
                table: "Encuesta");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UsuarioEmail",
                table: "Encuesta",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Encuesta_UsuarioEmail",
                table: "Encuesta",
                newName: "IX_Encuesta_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encuesta_AspNetUsers_UsuarioId",
                table: "Encuesta",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
