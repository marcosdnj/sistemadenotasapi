using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemaEscolar.Migrations
{
    public partial class BdAttAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "NotaFinal",
                table: "Aluno",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Recuperacao",
                table: "Aluno",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaFinal",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Recuperacao",
                table: "Aluno");
        }
    }
}
