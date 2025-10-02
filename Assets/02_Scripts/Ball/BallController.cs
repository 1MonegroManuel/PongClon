using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall(); // 🔹 Se lanza inmediatamente al inicio
    }

    void LaunchBall()
    {
        // X decide si va izquierda o derecha
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        // Y da un ángulo vertical pequeño aleatorio
        float y = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Aumenta velocidad progresivamente en cada rebote
        rb.velocity = rb.velocity.normalized * (speed += 0.1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GoalLeft"))
        {
            ScoreManager.Instance.AddPoint(false); // Punto para derecha
            ResetBall();
        }
        else if (col.CompareTag("GoalRight"))
        {
            ScoreManager.Instance.AddPoint(true); // Punto para izquierda
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        speed = 6f;

        Invoke("LaunchBall", 1f); // 🔹 Se relanza después de 1 segundo
    }
}
