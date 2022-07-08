using System.Collections.Generic;

namespace sistemaEscolar.Model
{
    public class AlunoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public float Nota1 { get; set; }

        public float Nota2 { get; set; }

        public float Nota3 { get; set; }

        public float Media { get; set; }
        public ICollection<ProfessorModel> Professor { get; set; }

        public bool Recuperacao { get; set; }

        public bool Aprovado { get; set; }
        public bool Reprovado { get; set; }

        public float NotaRecuperacao { get; set; }


        public float NotaFinal { get; set; }
    }
}
