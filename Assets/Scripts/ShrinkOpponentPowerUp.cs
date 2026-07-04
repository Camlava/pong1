using System.Collections;
using UnityEngine;

public class ShrinkOpponentPowerUp : MonoBehaviour
{
    public float shrinkFactor = 0.6f;
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
            Transform opponent = GetOpponent(other.transform);

            StartCoroutine(Shrink(opponent));

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    Transform GetOpponent(Transform paddle)
    {
        if (paddle.CompareTag("LeftPaddle"))
            return GameObject.FindGameObjectWithTag("RightPaddle").transform;

        return GameObject.FindGameObjectWithTag("LeftPaddle").transform;
    }

    IEnumerator Shrink(Transform paddle)
    {
        Vector3 original = paddle.localScale;

        paddle.localScale = new Vector3(
            original.x,
            original.y * shrinkFactor,
            original.z
        );

        yield return new WaitForSeconds(duration);

        paddle.localScale = original;

        Destroy(gameObject);
    }
}