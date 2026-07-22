using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool leftGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball"))
            return;


        if (ScoreSettings.battleMode)
        {
            // Battle Mode
            if (leftGoal)
            {
                // Ball went into left side goal
                // Left player loses health
                BattleManager.Instance.DamageLeft();
            }
            else
            {
                // Ball went into right side goal
                // Right player loses health
                BattleManager.Instance.DamageRight();
            }

            return;
        }


        // Normal Pong
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