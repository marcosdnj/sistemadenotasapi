using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemaEscolar.Migrations
{
    public partial class ReprovadoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reprovado",
                table: "Aluno",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reprovado",
                table: "Aluno");
        }
    }
}
