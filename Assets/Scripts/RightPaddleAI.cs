using UnityEngine;

public class RightPaddleAI : MonoBehaviour
{
    public Transform ball;
    public float speed = 6f;

    public float topLimit = 4.5f;
    public float bottomLimit = -4.5f;


    void Update()
    {
        // AI only works when playing against CPU
        if (!ScoreSettings.singlePlayer)
            return;


        if (ball == null)
            return;


        Vector3 target = new Vector3(
            transform.position.x,
            ball.position.y,
            transform.position.z
        );


        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );


        ClampPosition();
    }



    void ClampPosition()
    {
        Vector3 pos = transform.position;

        pos.y = Mathf.Clamp(
            pos.y,
            bottomLimit,
            topLimit
        );

        transform.position = pos;
    }
}