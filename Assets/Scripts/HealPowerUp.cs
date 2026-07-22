using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healAmount = 1;
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
    Debug.Log("Touched Object: " + other.name);
    Debug.Log("Tag: " + other.tag);

    if (other.CompareTag("LeftPaddle"))
    {
        Debug.Log("Healing LEFT");
        BattleManager.Instance.HealLeft(healAmount);
    }
    else if (other.CompareTag("RightPaddle"))
    {
        Debug.Log("Healing RIGHT");
        BattleManager.Instance.HealRight(healAmount);
    }

    PowerUpSpawner spawner = FindAnyObjectByType<PowerUpSpawner>();

    if (spawner != null)
        spawner.PowerUpCollected();

    Destroy(gameObject);
}
}