using UnityEngine;

public class RageModePowerUp : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float speedMultiplier = 1.75f;
    public float duration = 8f;


    void Start()
    {
        // Random left or right direction
        moveSpeed *= Random.value > 0.5f ? 1 : -1;
    }



    void Update()
    {
        // Move sideways
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);


        if(Mathf.Abs(transform.position.x) > 10f)
        {
            PowerUpSpawner spawner = FindAnyObjectByType<PowerUpSpawner>();

            if(spawner != null)
            {
                spawner.PowerUpCollected();
            }

            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("LeftPaddle") || other.CompareTag("RightPaddle"))
        {
            PaddleStats stats = other.GetComponent<PaddleStats>();

            if(stats != null)
            {
                stats.StartSpeedBoost(speedMultiplier, duration);
            }


            PowerUpSpawner spawner = FindAnyObjectByType<PowerUpSpawner>();

            if(spawner != null)
            {
                spawner.PowerUpCollected();
            }


            Destroy(gameObject);
        }
    }
}