using System.Collections;
using UnityEngine;

public class LongPaddlePowerUp : MonoBehaviour
{
    public float scaleMultiplier = 1.5f;
    public float duration = 10f;

    public float moveSpeed = 2f;

    void Start()
    {
        Debug.Log("PowerUp START running");

        // Random left or right direction
        moveSpeed *= Random.value > 0.5f ? 1 : -1;
    }

    void Update()
    {
        // Move sideways
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
            stats.StartLongPaddle(scaleMultiplier, duration);
        }

        PowerUpSpawner spawner = FindAnyObjectByType<PowerUpSpawner>();

        if (spawner != null)
        {
            spawner.PowerUpCollected();
        }

        Destroy(gameObject);
    }
    }

    void OnDestroy()
    {
        Debug.Log("LONG PADDLE POWERUP DESTROYED");
    }
}