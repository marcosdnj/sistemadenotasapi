using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using sistemaEscolar.Model;

namespace sistemaEscolar.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SalaModel> Sala { get; set; }
        public DbSet<ProfessorModel> Professor { get; set; }
        public DbSet<AlunoModel> Aluno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder) => optionsBuilder.UseSqlServer
            ("Data Source=DESKTOP-ABFE7AQ\\SQLEXPRESS;Initial Catalog=EscolaSistema; Integrated Security=True");




    }
}
