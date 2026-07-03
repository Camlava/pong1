using UnityEngine;

public class RightPaddleController : MonoBehaviour
{
    public float speed = 8f;

    // screen limits (adjust if needed)
    public float topLimit = 4.5f;
    public float bottomLimit = -4.5f;

    void Update()
{
    if (ScoreManager.Instance != null &&
        ScoreManager.Instance.singlePlayer)
    {
        return; // AI will control later
    }

    float move = 0f;

    if (Input.GetKey(KeyCode.UpArrow))
        move = 1f;

    if (Input.GetKey(KeyCode.DownArrow))
        move = -1f;

    transform.position += Vector3.up * move * speed * Time.deltaTime;

    ClampPosition();
}

    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);
        transform.position = pos;
    }
}