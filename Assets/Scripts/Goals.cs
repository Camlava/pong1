using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        if (isLeftGoal)
        {
            GameManager.Instance.RightScores();
        }
        else
        {
            GameManager.Instance.LeftScores();
        }
    }
}
