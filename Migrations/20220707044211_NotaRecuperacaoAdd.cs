using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemaEscolar.Migrations
{
    public partial class NotaRecuperacaoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "NotaRecuperacao",
                table: "Aluno",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaRecuperacao",
                table: "Aluno");
        }
    }
}
