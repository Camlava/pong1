using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public PaddleStats stats;

    void Awake()
{
    if (stats == null)
        stats = GetComponent<PaddleStats>();
}
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * stats.moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * stats.moveSpeed * Time.deltaTime;
        }
    }
}