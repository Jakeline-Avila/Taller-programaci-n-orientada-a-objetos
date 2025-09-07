using System;

namespace Proyecto
{
    class Agente
    {
        private int posicion;
        private int velocidad;

        public Agente(int posicionInicial, int velocidad)
        {
            this.posicion = posicionInicial;
            this.velocidad = velocidad;
        }

        public bool MoverHacia(int objetivo)
        {
            if (posicion < objetivo)
            {
                posicion += velocidad;
                if (posicion > objetivo)
                    posicion = objetivo;
            }
            else if (posicion > objetivo)
            {
                posicion -= velocidad;
                if (posicion < objetivo)
                    posicion = objetivo;
            }

            Console.WriteLine($"Agente en posición: {posicion}");

            return posicion == objetivo;
        }

        public int GetPosicion()
        {
            return posicion;
        }
    }
}
