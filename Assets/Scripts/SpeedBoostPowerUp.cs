using System.Collections;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    public float speedMultiplier = 1.5f;
    public float duration = 8f;

    public float moveSpeed = 2f;

    void Start()
    {
        moveSpeed *= Random.value > 0.5f ? 1 : -1;
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("LeftPaddle") || other.CompareTag("RightPaddle"))
    {
        PaddleStats stats = other.GetComponent<PaddleStats>();

        if (stats != null)
        {
            stats.StartSpeedBoost(speedMultiplier, duration);
        }

        Destroy(gameObject);
    }
}

    
}