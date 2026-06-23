using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Mode")]
    public bool singlePlayer = true;

    [Header("References")]
    public BallMovement ball;
    public AIPaddle ai;

    [Header("Score")]
    public int leftScore;
    public int rightScore;
    public int winScore = 5;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ai.enabled = singlePlayer;
        StartCoroutine(ServeBall());
    }

    public void LeftScores()
    {
        leftScore++;
        CheckWin();
        ResetRound();
    }

    public void RightScores()
    {
        rightScore++;
        CheckWin();
        ResetRound();
    }

    void CheckWin()
    {
        if (leftScore >= winScore)
            Debug.Log("Left Wins!");

        if (rightScore >= winScore)
            Debug.Log("Right Wins!");
    }

    void ResetRound()
    {
        ball.ResetBall();
        StartCoroutine(ServeBall());
    }

    IEnumerator ServeBall()
    {
        yield return new WaitForSeconds(1f);
        ball.Launch();
    }
}