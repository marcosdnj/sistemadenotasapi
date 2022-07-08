using System.Collections.Generic;

namespace sistemaEscolar.Model
{
    public class ProfessorModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<SalaModel> Sala { get; set; }
        public ICollection<AlunoModel> Aluno { get; set; }
    }
}
