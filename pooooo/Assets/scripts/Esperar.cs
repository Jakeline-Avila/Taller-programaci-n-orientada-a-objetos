using UnityEngine;

namespace BehaviorTree
{
    public class Esperar : ITarea
    {
        private readonly float duracion;
        private float tiempoRestante;

        public Esperar(float duracion)
        {
            this.duracion = Mathf.Max(0f, duracion);
            this.tiempoRestante = this.duracion;
        }

        public Estado Ejecutar()
        {
            if (duracion <= 0f) return Estado.Exito;

            if (tiempoRestante > 0f)
            {
                tiempoRestante -= Time.deltaTime;
                return Estado.EnProgreso;
            }

            
            return Estado.Exito;
        }

        public void Reiniciar()
        {
            tiempoRestante = duracion;
        }
    }
}
