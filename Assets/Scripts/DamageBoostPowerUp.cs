using UnityEngine;

public class DamageBoostPowerUp : MonoBehaviour
{
    public float moveSpeed = 2f;


    void Start()
    {
        moveSpeed *= Random.value > 0.5f ? 1 : -1;
    }



    void Update()
    {
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
                    BattleManager.Instance.ActivateDamageBoost(true);
                }
                else
                {
                    BattleManager.Instance.ActivateDamageBoost(false);
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