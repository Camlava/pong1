using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float moveSpeed = 2f;


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
            if(BattleManager.Instance != null)
            {
                if(other.CompareTag("LeftPaddle"))
                {
                    BattleManager.Instance.ActivateShield(true);
                }
                else
                {
                    BattleManager.Instance.ActivateShield(false);
                }
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