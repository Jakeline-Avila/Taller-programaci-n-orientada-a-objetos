using Proyecto;

namespace Proyecto
{
    class Selector : Compuesto
    {
        private System.Func<bool> condicion;

        public Selector(System.Func<bool> condicion = null)
        {
            this.condicion = condicion;
        }

        private bool Evaluar()
        {
            if (condicion == null) return true; // si no hay condición, siempre pasa
            return condicion();
        }

        public override bool Ejecutar()
        {
            if (!Evaluar()) return false;

            foreach (var hijo in hijos)
            {
                if (hijo.Ejecutar())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
