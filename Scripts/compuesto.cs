using System.Collections.Generic;

namespace BehaviorTree
{
    public abstract class NodoCompuesto : ITarea
    {
        protected readonly List<ITarea> hijos = new List<ITarea>();

        public void AgregarHijo(ITarea hijo)
        {
            if (hijo != null) hijos.Add(hijo);
        }

        public abstract Estado Ejecutar();

        public virtual void Reiniciar()
        {
            foreach (var h in hijos) h.Reiniciar();
        }
    }
}
