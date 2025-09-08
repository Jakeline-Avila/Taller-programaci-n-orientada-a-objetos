using UnityEngine;

namespace BehaviorTree
{
    public class Saltar : ITarea
    {
        private readonly Agente agente;
        private readonly float fuerzaSalto;
        private bool saltoEjecutado = false;

        public Saltar(Agente agente, float fuerzaSalto = 6f)
        {
            this.agente = agente;
            this.fuerzaSalto = fuerzaSalto;
        }

        public Estado Ejecutar()
        {
            if (agente == null) return Estado.Falla;

            if (!saltoEjecutado)
            {
                agente.Saltar(fuerzaSalto);
                saltoEjecutado = true;
                Debug.Log("[Saltar] El agente ha saltado.");
            }

            return Estado.Exito; // acción instantánea
        }

        public void Reiniciar()
        {
            saltoEjecutado = false;
        }
    }
}