using System;
using Proyecto;

namespace Proyecto
{
    class Raiz : Nodo
    {
        private Nodo hijo;

        public Raiz(Nodo hijo)
        {
            this.hijo = hijo;
        }

        public override bool Ejecutar()
        {
            if (hijo != null)
            {
                return hijo.Ejecutar();
            }
            return false;
        }
    }
}
