using Proyecto;

namespace Proyecto
{
    class Secuencia : Compuesto
    {
        public override bool Ejecutar()
        {
            foreach (var hijo in hijos)
            {
                if (!hijo.Ejecutar())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
