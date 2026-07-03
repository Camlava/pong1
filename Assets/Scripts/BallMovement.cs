using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 7f;

    public float speedIncrease = 0.3f;
    private Rigidbody2D rb;

    void Start()
{
    Launch();
}

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.6f, 0.6f);

        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * speed;
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void IncreaseSpeed()
    {
    rb.linearVelocity *= (1f + speedIncrease);
    }
}

    
