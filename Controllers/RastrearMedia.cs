namespace sistemaEscolar.Controllers
{
    public class RastrearMedia
    {
        public float media;
        public float notaRecuperacao;
        public float notaFinal;
        public bool reprovado;
        public bool recuperacao;


        public bool calcRecuperacao(float media)
        {
            if (media > 4 && media < 6) 
                return true;
                          
            if (media < 4)
                return false;
                           
            return false;                  
        }

        public bool calcReprovacao(float media)
        {
            if (media < 4)
                return true;
            
            return false;
        }

        public float CalcNotaFinal(float media, float notaRecuperacao)
        {
            notaFinal = (media + notaRecuperacao) / 2;

            return notaFinal;
        }

        public bool situacaofinal(float media, float notarecuperacao)
        {

            if (((media + notarecuperacao) / 2) > 5)
                return true;
            else
                return false;
        }

    }
}
