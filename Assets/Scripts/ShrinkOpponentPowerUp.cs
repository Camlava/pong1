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

        PaddleStats stats = opponent.GetComponent<PaddleStats>();

        if (stats != null)
        {
            stats.StartShrink(shrinkFactor, duration);
        }

        Destroy(gameObject);
    }
}

    Transform GetOpponent(Transform paddle)
    {
        if (paddle.CompareTag("LeftPaddle"))
            return GameObject.FindGameObjectWithTag("RightPaddle").transform;

        return GameObject.FindGameObjectWithTag("LeftPaddle").transform;
    }

    
}