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
        PaddleStats stats = other.GetComponentInParent<PaddleStats>();

        if (stats != null)
        {
            StartCoroutine(ApplyBoost(stats));

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator ApplyBoost(PaddleStats stats)
    {
        stats.moveSpeed *= speedMultiplier;

        yield return new WaitForSeconds(duration);

        stats.moveSpeed /= speedMultiplier;

        Destroy(gameObject);
    }
}