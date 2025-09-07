using System.Threading;
using Proyecto;

namespace Proyecto
{
    class MoverAlObjetivo : Tarea
    {
        private Agente agente;
        private int objetivo;

        public MoverAlObjetivo(Agente agente, int objetivo)
        {
            this.agente = agente;
            this.objetivo = objetivo;
        }

        public override bool Ejecutar()
        {
            bool llego = false;

            while (!llego)
            {
                llego = agente.MoverHacia(objetivo);
                Thread.Sleep(500); // pausa para simular movimiento
            }

            return true;
        }
    }
}
