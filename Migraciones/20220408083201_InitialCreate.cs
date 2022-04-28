using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaenlaceNet.Migraciones
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    CitaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivocita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteUsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    medicoUsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_Cita_Medico_medicoUsuarioId",
                        column: x => x.medicoUsuarioId,
                        principalTable: "Medico",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_pacienteUsuarioId",
                        column: x => x.pacienteUsuarioId,
                        principalTable: "Paciente",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "MedicoPaciente",
                columns: table => new
                {
                    medicosUsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    pacientesUsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoPaciente", x => new { x.medicosUsuarioId, x.pacientesUsuarioId });
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Medico_medicosUsuarioId",
                        column: x => x.medicosUsuarioId,
                        principalTable: "Medico",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Paciente_pacientesUsuarioId",
                        column: x => x.pacientesUsuarioId,
                        principalTable: "Paciente",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    DiagnosticoId = table.Column<long>(type: "bigint", nullable: false),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.DiagnosticoId);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Cita_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Cita",
                        principalColumn: "CitaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_medicoUsuarioId",
                table: "Cita",
                column: "medicoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_pacienteUsuarioId",
                table: "Cita",
                column: "pacienteUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoPaciente_pacientesUsuarioId",
                table: "MedicoPaciente",
                column: "pacientesUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "MedicoPaciente");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
