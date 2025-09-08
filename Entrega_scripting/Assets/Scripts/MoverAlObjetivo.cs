using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace BehaviorTree
{
    public class MoverAlObjetivo : ITarea
    {
        private readonly Agente agente;
        private readonly Transform objetivo;
        private readonly float stopDistance;
        private readonly float velocidad;

        private float logInterval = 0.25f;
        private float logTimer = 0f;

        public MoverAlObjetivo(Agente agente, Transform objetivo, float velocidad = 5f, float stopDistance = 0.2f)
        {
            this.agente = agente;
            this.objetivo = objetivo;
            this.velocidad = velocidad;
            this.stopDistance = stopDistance;
        }

        public Estado Ejecutar()
        {
            if (agente == null || objetivo == null) return Estado.Falla;

            Vector3 pos = agente.GetPosicion();
            Vector3 target = objetivo.position;
            float d = Vector3.Distance(pos, target);

            if (d <= stopDistance)
            {
                Debug.Log($"[Mover] Llegué al objetivo (d={d:0.00} ≤ stopDistance={stopDistance}).");
                return Estado.Exito;
            }

            Vector3 dir = (target - pos).normalized;
            agente.Mover(dir * velocidad * Time.deltaTime);

            logTimer += Time.deltaTime;
            if (logTimer >= logInterval)
            {
                Debug.Log($"[Mover] Distancia al objetivo: {d:0.00}");
                logTimer = 0f;
            }

            return Estado.EnProgreso;
        }

        public void Reiniciar()
        {
            logTimer = 0f;
        }
    }
}