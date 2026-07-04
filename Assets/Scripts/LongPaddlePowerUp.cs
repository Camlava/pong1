using System.Collections;
using UnityEngine;

public class LongPaddlePowerUp : MonoBehaviour
{
    public float scaleMultiplier = 1.5f;
    public float duration = 10f;

    public float moveSpeed = 2f;   // NEW

    void Start()
{
    Debug.Log("PowerUp START running");
    // Random left or right direction
    moveSpeed *= Random.value > 0.5f ? 1 : -1;
}

    void Update()
    {
        // Move sideways (left or right depending on spawn direction)
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        
    if (Mathf.Abs(transform.position.x) > 10f)
    {
        Destroy(gameObject);
    }
    Debug.Log("PowerUp UPDATE running");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftPaddle") || other.CompareTag("RightPaddle"))
        {
            StartCoroutine(ApplyPowerUp(other.transform));

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator ApplyPowerUp(Transform paddle)
    {
        Vector3 originalScale = paddle.localScale;

        paddle.localScale = new Vector3(
            originalScale.x,
            originalScale.y * scaleMultiplier,
            originalScale.z
        );

        yield return new WaitForSeconds(duration);

        paddle.localScale = originalScale;

        Destroy(gameObject);
    }

   
}