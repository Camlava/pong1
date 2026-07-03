using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<BallMovement>().IncreaseSpeed();
        }
    }
}