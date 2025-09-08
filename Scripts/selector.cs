using System;

namespace BehaviorTree
{
   
    public class Selector : NodoCompuesto
    {
        private readonly Func<bool> condicion;
        private int indiceActual = 0;

        public Selector(Func<bool> condicion)
        {
            this.condicion = condicion ?? (() => true);
        }

        public override Estado Ejecutar()
        {
            if (!condicion())
            {
               
                return Estado.Falla;
            }

            while (indiceActual < hijos.Count)
            {
                var estado = hijos[indiceActual].Ejecutar();

                switch (estado)
                {
                    case Estado.Exito:
                        return Estado.Exito;

                    case Estado.EnProgreso:
                        return Estado.EnProgreso;

                    case Estado.Falla:
                        indiceActual++;
                        continue;
                }
            }

          
            return Estado.Falla;
        }

        public override void Reiniciar()
        {
            base.Reiniciar();
            indiceActual = 0;
        }
    }
}
