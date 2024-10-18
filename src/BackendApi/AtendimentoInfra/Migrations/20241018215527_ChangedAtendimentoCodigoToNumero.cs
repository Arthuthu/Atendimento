using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendimentoInfra.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAtendimentoCodigoToNumero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Atendimento",
                newName: "Numero");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_Codigo",
                table: "Atendimento",
                newName: "IX_Atendimento_Numero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Atendimento",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_Numero",
                table: "Atendimento",
                newName: "IX_Atendimento_Codigo");
        }
    }
}
