namespace BehaviorTree
{
   
    public class Raiz
    {
        private readonly ITarea raiz;

        public Raiz(ITarea raiz)
        {
            this.raiz = raiz;
        }

        public Estado Ejecutar()
        {
            return raiz.Ejecutar();
        }

        public void Reiniciar()
        {
            raiz.Reiniciar();
        }
    }
}
