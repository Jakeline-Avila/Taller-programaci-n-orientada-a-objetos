using UnityEngine;

namespace BehaviorTree
{
    public class BehaviorTreeManager : MonoBehaviour
    {
        [Header("Referencias")]
        public Agente agente;
        public Transform objetivo;

        [Header("Parámetros")]
        public float distanciaValida = 12f;
        public float stopDistance = 0.2f;
        public float velocidadAgente = 5f;
        public float tiempoEspera = 2f;

        private Raiz raiz;

        void Start()
        {
            var mover = new MoverAlObjetivo(agente, objetivo, velocidadAgente, stopDistance);
            var esperar = new Esperar(tiempoEspera);

            var selectorDistancia = new Selector(() =>
            {
                if (agente == null || objetivo == null) return false;
                float d = Vector2.Distance(objetivo.position, agente.GetPosicion());
                Debug.Log($"[Selector] d={d:0.00}  (distanciaValida={distanciaValida})");
                return d <= distanciaValida;
            });
            selectorDistancia.AgregarHijo(mover);

            var secuencia = new Secuencia();
            secuencia.AgregarHijo(selectorDistancia);
            secuencia.AgregarHijo(esperar);

            raiz = new Raiz(secuencia);
        }

        void Update()
        {
            if (raiz == null) return;
            var estado = raiz.Ejecutar();

            if (estado == Estado.Exito || estado == Estado.Falla)
                raiz.Reiniciar();
        }
    }
}
