using UnityEngine;

public class RightPaddleController : MonoBehaviour
{
    public float speed = 8f;

    void Upate()
    {
        float move = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            move = -1f;
        }
        transform.position += new Vector3(0f, move * speed * Time.deltaTime, 0f);
    }
}