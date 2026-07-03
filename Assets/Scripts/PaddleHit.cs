using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    public SoundManager soundManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            soundManager.playSound();
            collision.gameObject.GetComponent<BallMovement>().IncreaseSpeed();
        }
    }
}