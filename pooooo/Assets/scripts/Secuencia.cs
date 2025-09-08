namespace BehaviorTree
{
  
    public class Secuencia : NodoCompuesto
    {
        private int indiceActual = 0;

        public override Estado Ejecutar()
        {
            while (indiceActual < hijos.Count)
            {
                var estado = hijos[indiceActual].Ejecutar();

                switch (estado)
                {
                    case Estado.Exito:
                        indiceActual++;
                        continue;

                    case Estado.EnProgreso:
                        return Estado.EnProgreso;

                    case Estado.Falla:
                        return Estado.Falla;
                }
            }

           
            return Estado.Exito;
        }

        public override void Reiniciar()
        {
            base.Reiniciar();
            indiceActual = 0;
        }
    }
}
