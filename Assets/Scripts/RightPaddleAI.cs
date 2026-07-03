using UnityEngine;

public class RightPaddleAI : MonoBehaviour
{
    public Transform ball;
    public float speed = 6f;

    void Update()
    {
        if (!ScoreManager.Instance.singlePlayer) return;

        Vector3 target = new Vector3(
            transform.position.x,
            ball.position.y,
            0
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }
}