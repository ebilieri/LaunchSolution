using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Launch.Repository.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    ImagemUrl = table.Column<string>(maxLength: 400, nullable: true),
                    Senha = table.Column<string>(maxLength: 400, nullable: false),
                    ConfirmaSenha = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoId = table.Column<int>(nullable: false),
                    DataVotacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacao_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotacaoDiaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoId = table.Column<int>(nullable: false),
                    DataVotacao = table.Column<DateTime>(nullable: false),
                    TotalVotosDia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotacaoDiaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotacaoDiaria_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotacaoSemanal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoId = table.Column<int>(nullable: false),
                    NumeroSemana = table.Column<int>(nullable: false),
                    TotalVotosSemana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotacaoSemanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotacaoSemanal_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_CandidatoId",
                table: "Votacao",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_VotacaoDiaria_CandidatoId",
                table: "VotacaoDiaria",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_VotacaoSemanal_CandidatoId",
                table: "VotacaoSemanal",
                column: "CandidatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votacao");

            migrationBuilder.DropTable(
                name: "VotacaoDiaria");

            migrationBuilder.DropTable(
                name: "VotacaoSemanal");

            migrationBuilder.DropTable(
                name: "Candidato");
        }
    }
}
