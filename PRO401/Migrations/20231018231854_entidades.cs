using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRO401.Migrations
{
    /// <inheritdoc />
    public partial class entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "AspNetUsers",
                newName: "TipoTrabajoId");

            migrationBuilder.RenameColumn(
                name: "ComunaId",
                table: "AspNetUsers",
                newName: "EstadoRegistroId");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ComunaResidenciaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComunaTrabajoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Run",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoRegistro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoRegistro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTrabajo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comparte = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoEncuesta = table.Column<int>(type: "int", nullable: false),
                    TiempoAproximado = table.Column<int>(type: "int", nullable: false),
                    KmAproximado = table.Column<int>(type: "int", nullable: false),
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encuesta_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encuesta_TipoTransporte_TipoTransporteId",
                        column: x => x.TipoTransporteId,
                        principalTable: "TipoTransporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporte_TipoTransporte_TipoTransporteId",
                        column: x => x.TipoTransporteId,
                        principalTable: "TipoTransporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ComunaResidenciaId",
                table: "AspNetUsers",
                column: "ComunaResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ComunaTrabajoId",
                table: "AspNetUsers",
                column: "ComunaTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstadoRegistroId",
                table: "AspNetUsers",
                column: "EstadoRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipoTrabajoId",
                table: "AspNetUsers",
                column: "TipoTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuesta_TipoTransporteId",
                table: "Encuesta",
                column: "TipoTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuesta_UsuarioId",
                table: "Encuesta",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transporte_TipoTransporteId",
                table: "Transporte",
                column: "TipoTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comuna_ComunaResidenciaId",
                table: "AspNetUsers",
                column: "ComunaResidenciaId",
                principalTable: "Comuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comuna_ComunaTrabajoId",
                table: "AspNetUsers",
                column: "ComunaTrabajoId",
                principalTable: "Comuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EstadoRegistro_EstadoRegistroId",
                table: "AspNetUsers",
                column: "EstadoRegistroId",
                principalTable: "EstadoRegistro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoTrabajo_TipoTrabajoId",
                table: "AspNetUsers",
                column: "TipoTrabajoId",
                principalTable: "TipoTrabajo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comuna_ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comuna_ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EstadoRegistro_EstadoRegistroId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoTrabajo_TipoTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comuna");

            migrationBuilder.DropTable(
                name: "Encuesta");

            migrationBuilder.DropTable(
                name: "EstadoRegistro");

            migrationBuilder.DropTable(
                name: "TipoTrabajo");

            migrationBuilder.DropTable(
                name: "Transporte");

            migrationBuilder.DropTable(
                name: "TipoTransporte");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EstadoRegistroId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TipoTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Run",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TipoTrabajoId",
                table: "AspNetUsers",
                newName: "Edad");

            migrationBuilder.RenameColumn(
                name: "EstadoRegistroId",
                table: "AspNetUsers",
                newName: "ComunaId");
        }
    }
}
