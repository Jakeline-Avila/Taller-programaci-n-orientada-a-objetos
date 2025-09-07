using System;
using Proyecto;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            // 🔹 Variables iniciales
            int posicionInicial = 0;
            int objetivo = 10;
            int distanciaValida = 12;
            int tiempoEspera = 2000; // milisegundos

            Agente agente = new Agente(posicionInicial, 2);

            // --- Construcción del árbol de comportamiento ---

            // Tarea de moverse al objetivo
            var mover = new MoverAlObjetivo(agente, objetivo);

            // Selector que evalúa si la distancia es válida
            var selectorDistancia = new Selector(() =>
            {
                int distancia = Math.Abs(objetivo - agente.GetPosicion());
                Console.WriteLine($"Distancia actual al objetivo: {distancia}");
                return distancia <= distanciaValida;
            });
            selectorDistancia.AgregarHijo(mover);

            // Tarea de esperar
            var esperar = new Esperar(tiempoEspera);

            // Secuencia que ejecuta: 1) el selector 2) esperar
            var secuencia = new Secuencia();
            secuencia.AgregarHijo(selectorDistancia);
            secuencia.AgregarHijo(esperar);

            // Raíz del árbol
            var raiz = new Raiz(secuencia);

            // 🔹 Bucle de ejecución
            Console.WriteLine("Iniciando árbol de comportamiento...\n");

            for (int i = 0; i < 3; i++) // se repite 3 ciclos de prueba
            {
                Console.WriteLine($"\n--- Ciclo {i + 1} ---");
                raiz.Ejecutar();
            }

            Console.WriteLine("\nSimulación terminada.");
        }
    }
}
