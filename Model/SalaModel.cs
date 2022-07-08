using System.Collections.Generic;

namespace sistemaEscolar.Model
{
    public class SalaModel
    {
        public int Id { get; set; }

        public string Identificador { get; set; }

        public ICollection<AlunoModel> Alunos { get; set; }

        public ICollection<ProfessorModel> Professores { get; set; }
    }
}
