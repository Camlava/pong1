using UnityEngine;
using TMPro;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;

    [Header("References")]
    public ScoreManager scoreManager;
    public BallMovement ball;

    public PaddleStats leftStats;
    public PaddleStats rightStats;

    [Header("Mode UI")]
    public TextMeshProUGUI modeText;

    private float normalBallSpeed;
    private float normalLeftSpeed;
    private float normalRightSpeed;

    private Vector3 leftScale;
    private Vector3 rightScale;

    private bool dangerMode;
    private bool angelMode;


    // Used by PowerUpSpawner
    public bool AngelModeActive
    {
        get { return angelMode; }
    }


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        normalBallSpeed = ball.speed;

        normalLeftSpeed = leftStats.moveSpeed;
        normalRightSpeed = rightStats.moveSpeed;

        leftScale = leftStats.transform.localScale;
        rightScale = rightStats.transform.localScale;

        if (modeText != null)
            modeText.gameObject.SetActive(false);
    }


    public void CheckModes()
    {
        ResetModes();

        CheckDangerMode();
        CheckAngelMode();
    }


    void CheckDangerMode()
    {
        int diff = Mathf.Abs(scoreManager.leftScore - scoreManager.rightScore);

        if (diff < 2)
            return;


        dangerMode = true;

        ball.SetSpeed(normalBallSpeed * 1.25f);

        ShowMessage("🔥 DANGER MODE!", Color.red);
    }


    void CheckAngelMode()
    {
        // Left player is at game point
        if (scoreManager.leftScore == scoreManager.winScore - 1 &&
            scoreManager.leftScore > scoreManager.rightScore)
        {
            ApplyAngel(rightStats);
        }


        // Right player is at game point
        if (scoreManager.rightScore == scoreManager.winScore - 1 &&
            scoreManager.rightScore > scoreManager.leftScore)
        {
            ApplyAngel(leftStats);
        }
    }


    void ApplyAngel(PaddleStats losingPlayer)
    {
        angelMode = true;


        // Slight speed boost
        losingPlayer.moveSpeed *= 1.15f;


        // Larger paddle
        losingPlayer.transform.localScale = new Vector3(
            losingPlayer.transform.localScale.x,
            losingPlayer.transform.localScale.y * 1.25f,
            losingPlayer.transform.localScale.z
        );


        // Slower ball for comeback chance
        float ballSpeed;

        if (dangerMode)
        {
            ballSpeed = normalBallSpeed * 1.15f;
        }
        else
        {
            ballSpeed = normalBallSpeed * 0.9f;
        }


        ball.SetSpeed(ballSpeed);


        ShowMessage("😇 ANGEL MODE!\nComeback Time!", Color.yellow);
    }


    void ResetModes()
    {
        ball.SetSpeed(normalBallSpeed);

        leftStats.moveSpeed = normalLeftSpeed;
        rightStats.moveSpeed = normalRightSpeed;


        leftStats.transform.localScale = leftScale;
        rightStats.transform.localScale = rightScale;


        dangerMode = false;
        angelMode = false;
    }


    void ShowMessage(string text, Color color)
    {
        if (modeText == null)
            return;


        modeText.text = text;
        modeText.color = color;

        modeText.gameObject.SetActive(true);


        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 2f);
    }


    void HideMessage()
    {
        if (modeText != null)
        {
            modeText.gameObject.SetActive(false);
        }
    }
}