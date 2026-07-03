using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public bool singlePlayer => ScoreSettings.singlePlayer;
    public RightPaddleController rightPaddle;
    private BallMovement ball;
    private Rigidbody2D ballRb;

    public int winScore = 5;
    public GameObject winText;


    public int leftScore;
    public int rightScore;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
{
    winText.SetActive(false);
    leftScoreText.text = "0";
    rightScoreText.text = "0";
    ball = FindAnyObjectByType<BallMovement>();
    ballRb = ball.GetComponent<Rigidbody2D>();
}

    public void LeftScores()
    {
    leftScore++;
    leftScoreText.text = leftScore.ToString();

    if (leftScore >= winScore)
    {
        EndGame("Left Player Wins!");
        return;
    }

    ResetBall();
    }

    public void RightScores()
    {
    rightScore++;
    rightScoreText.text = rightScore.ToString();

    if (rightScore >= winScore)
    {
        EndGame("Right Player Wins!");
        return;
    }

    ResetBall();
    }

    void ResetBall()
    {
        BallMovement ball = FindAnyObjectByType<BallMovement>();
        ball.transform.position = Vector3.zero;

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        ball.Launch();
    }
    void EndGame(string message)
    {
    winText.SetActive(true);
    winText.GetComponent<TMPro.TextMeshProUGUI>().text = message;
    

    BallMovement ball = FindAnyObjectByType<BallMovement>();
    ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

    Debug.Log(message);
    }

    public void RestartGame()
    {
    leftScore = 0;
    rightScore = 0;

    leftScoreText.text = "0";
    rightScoreText.text = "0";

    winText.gameObject.SetActive(false);

    ball.transform.position = Vector3.zero;
    ballRb.linearVelocity = Vector2.zero;

    ball.Launch();
    }   

void Update()
    {
    if (Input.GetKeyDown(KeyCode.R))
    {
        RestartGame();
    }
    }
}
