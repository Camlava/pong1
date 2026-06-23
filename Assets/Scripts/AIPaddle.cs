using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed = 7f;

    void Update()
    {
        if (!GameManager.Instance.singlePlayer) return;

        Vector3 target = new Vector3(transform.position.x, ball.position.y, 0);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }
}