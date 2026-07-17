using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool leftGoal;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball"))
            return;


        // Battle Mode
        if (ScoreSettings.battleMode)
        {
            if (leftGoal)
            {
                // Ball entered left side
                BattleManager.Instance.DamageLeft();
            }
            else
            {
                // Ball entered right side
                BattleManager.Instance.DamageRight();
            }

            return;
        }


        // Normal Pong Mode
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