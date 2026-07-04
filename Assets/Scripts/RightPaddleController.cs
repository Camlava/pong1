using UnityEngine;

public class RightPaddleController : MonoBehaviour
{
    public PaddleStats stats;

    public float topLimit = 4.5f;
    public float bottomLimit = -4.5f;

    void Awake()
    {
        if (stats == null)
            stats = GetComponent<PaddleStats>();
    }

    void Update()
    {
        if (stats == null)
        {
            Debug.LogError("PaddleStats is missing on Right Paddle!");
            return;
        }

        if (ScoreManager.Instance != null &&
            ScoreManager.Instance.singlePlayer)
        {
            return;
        }

        float move = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            move = 1f;

        if (Input.GetKey(KeyCode.DownArrow))
            move = -1f;

        transform.position += Vector3.up * move * stats.moveSpeed * Time.deltaTime;

        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);
        transform.position = pos;
    }
}