using System;
using System.Threading;
using Proyecto;

namespace Proyecto
{
    class Esperar : Tarea
    {
        private int tiempo;

        public Esperar(int tiempo)
        {
            this.tiempo = tiempo;
        }

        public override bool Ejecutar()
        {
            Console.WriteLine($"Esperando {tiempo} ms...");
            Thread.Sleep(tiempo);
            return true;
        }
    }
}
