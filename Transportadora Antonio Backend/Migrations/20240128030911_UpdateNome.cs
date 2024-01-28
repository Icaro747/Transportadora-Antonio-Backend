using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transportadora_Antonio_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaEventosFuncionarios_Funcionarios_FuncionarioId",
                table: "RaEventosFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_RaEventosFuncionarios_Veiculos_VeiculoId",
                table: "RaEventosFuncionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaEventosFuncionarios",
                table: "RaEventosFuncionarios");

            migrationBuilder.RenameTable(
                name: "RaEventosFuncionarios",
                newName: "RelacaoFuncionarioVeiculo");

            migrationBuilder.RenameIndex(
                name: "IX_RaEventosFuncionarios_VeiculoId",
                table: "RelacaoFuncionarioVeiculo",
                newName: "IX_RelacaoFuncionarioVeiculo_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_RaEventosFuncionarios_FuncionarioId",
                table: "RelacaoFuncionarioVeiculo",
                newName: "IX_RelacaoFuncionarioVeiculo_FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelacaoFuncionarioVeiculo",
                table: "RelacaoFuncionarioVeiculo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelacaoFuncionarioVeiculo_Funcionarios_FuncionarioId",
                table: "RelacaoFuncionarioVeiculo",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelacaoFuncionarioVeiculo_Veiculos_VeiculoId",
                table: "RelacaoFuncionarioVeiculo",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelacaoFuncionarioVeiculo_Funcionarios_FuncionarioId",
                table: "RelacaoFuncionarioVeiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_RelacaoFuncionarioVeiculo_Veiculos_VeiculoId",
                table: "RelacaoFuncionarioVeiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelacaoFuncionarioVeiculo",
                table: "RelacaoFuncionarioVeiculo");

            migrationBuilder.RenameTable(
                name: "RelacaoFuncionarioVeiculo",
                newName: "RaEventosFuncionarios");

            migrationBuilder.RenameIndex(
                name: "IX_RelacaoFuncionarioVeiculo_VeiculoId",
                table: "RaEventosFuncionarios",
                newName: "IX_RaEventosFuncionarios_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_RelacaoFuncionarioVeiculo_FuncionarioId",
                table: "RaEventosFuncionarios",
                newName: "IX_RaEventosFuncionarios_FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaEventosFuncionarios",
                table: "RaEventosFuncionarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RaEventosFuncionarios_Funcionarios_FuncionarioId",
                table: "RaEventosFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaEventosFuncionarios_Veiculos_VeiculoId",
                table: "RaEventosFuncionarios",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
