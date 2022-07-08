namespace sistemaEscolar.Controllers
{
    public class CalculoMedia
    {
        public float nota1;
        public float nota2;
        public float nota3;
        public float media;
        public void calcularMedia(float nota1, float nota2, float nota3)
        {
             media = (float)(nota1 + (nota2 * 1.20) + (nota3 * 1.40))/(float)(1 + 1.2 + 1.40);          
        }

    }
}
