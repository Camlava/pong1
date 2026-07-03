using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool leftGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball"))
            return;

        if (leftGoal)
        {
            ScoreManager.Instance.RightScores();
        }
        else
        {
            ScoreManager.Instance.LeftScores();
        }
    }
}
