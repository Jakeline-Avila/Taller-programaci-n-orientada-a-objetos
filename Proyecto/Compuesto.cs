using System.Collections.Generic;
using Proyecto;

namespace Proyecto
{
    abstract class Compuesto : Nodo
    {
        protected List<Nodo> hijos = new List<Nodo>();

        public void AgregarHijo(Nodo hijo)
        {
            hijos.Add(hijo);
        }
    }
}
