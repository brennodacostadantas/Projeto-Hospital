using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoHospital.Migrations
{
    public partial class MigrationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiasSemanas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemanas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<string>(type: "char(2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(26)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Custo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SexoPaciente = table.Column<string>(type: "varchar(9)", nullable: false),
                    IdadePaciente = table.Column<string>(type: "varchar(15)", nullable: false),
                    Parametro = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorMinimo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorMaximo = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamesPlanos",
                columns: table => new
                {
                    IdExame = table.Column<int>(nullable: false),
                    IdPlano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamesPlanos", x => new { x.IdExame, x.IdPlano });
                    table.ForeignKey(
                        name: "FK_ExamesPlanos_Exames_IdExame",
                        column: x => x.IdExame,
                        principalTable: "Exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamesPlanos_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    CRM = table.Column<string>(type: "varchar(13)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(16)", nullable: true),
                    Total_atend = table.Column<int>(nullable: false),
                    EspecialidadeId = table.Column<int>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(9)", nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: false),
                    PlanoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    IdMedico = table.Column<int>(nullable: false),
                    IdPlano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => new { x.IdMedico, x.IdPlano });
                    table.ForeignKey(
                        name: "FK_Convenios_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Convenios_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    FormaPagamento = table.Column<string>(type: "varchar(8)", nullable: true),
                    PlanoId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    AtendePlano = table.Column<bool>(type: "bit", nullable: false),
                    AtendeDia = table.Column<bool>(type: "bit", nullable: false),
                    DiaSemanaId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    AtendimentoDaConsultaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Consultas_AtendimentoDaConsultaId",
                        column: x => x.AtendimentoDaConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_DiasSemanas_DiaSemanaId",
                        column: x => x.DiaSemanaId,
                        principalTable: "DiasSemanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrescricoesMedicamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    Medicamento = table.Column<string>(type: "varchar(20)", nullable: false),
                    FormaUso = table.Column<string>(type: "varchar(15)", nullable: false),
                    ConsultaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricoesMedicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescricoesMedicamentos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisicoesExames",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    DataRequisicao = table.Column<DateTime>(type: "datetime", nullable: false),
                    situacao = table.Column<int>(nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExameId = table.Column<int>(nullable: false),
                    ConsultaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicoesExames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisicoesExames_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisicoesExames_Exames_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_AtendimentoDaConsultaId",
                table: "Atendimentos",
                column: "AtendimentoDaConsultaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_DiaSemanaId",
                table: "Atendimentos",
                column: "DiaSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_MedicoId",
                table: "Atendimentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PlanoId",
                table: "Consultas",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_IdPlano",
                table: "Convenios",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstadoId",
                table: "Enderecos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamesPlanos_IdPlano",
                table: "ExamesPlanos",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EnderecoId",
                table: "Medicos",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PlanoId",
                table: "Pacientes",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicamentos_ConsultaId",
                table: "PrescricoesMedicamentos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicoesExames_ConsultaId",
                table: "RequisicoesExames",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicoesExames_ExameId",
                table: "RequisicoesExames",
                column: "ExameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "ExamesPlanos");

            migrationBuilder.DropTable(
                name: "PrescricoesMedicamentos");

            migrationBuilder.DropTable(
                name: "RequisicoesExames");

            migrationBuilder.DropTable(
                name: "DiasSemanas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
