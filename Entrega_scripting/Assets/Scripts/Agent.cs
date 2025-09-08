using UnityEngine;

public class Agente : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;   // en 3D usamos gravedad
            rb.freezeRotation = true;
        }
    }

    public Vector3 GetPosicion()
    {
        return transform.position;
    }

    public void Mover(Vector3 deltaMovimiento)
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + deltaMovimiento);
        }
        else
        {
            transform.position += deltaMovimiento;
        }
    }

    public void Saltar(float fuerzaSalto = 6f)
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }
}