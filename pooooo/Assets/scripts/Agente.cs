using UnityEngine;

public class Agente : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;          
            rb.freezeRotation = true;     
        }
    }

    public Vector2 GetPosicion()
    {
        return (Vector2)transform.position;
    }

 
    public void Mover(Vector2 deltaMovimiento)
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + deltaMovimiento);
        }
        else
        {
            transform.position += (Vector3)deltaMovimiento;
        }
    }
}


