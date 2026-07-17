using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public int maxHealth = 5;

    public int leftHealth;
    public int rightHealth;

    public TextMeshProUGUI leftHealthText;
    public TextMeshProUGUI rightHealthText;

    public GameObject battleWinPanel;
    public TextMeshProUGUI winnerText;


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        leftHealth = maxHealth;
        rightHealth = maxHealth;

        UpdateUI();
    }


    public void DamageLeft()
    {
        leftHealth--;

        UpdateUI();

        if(leftHealth <= 0)
        {
            EndBattle("Right Player Wins!");
            return;
        }

        ResetRound();
    }


    public void DamageRight()
    {
        rightHealth--;

        UpdateUI();

        if(rightHealth <= 0)
        {
            EndBattle("Left Player Wins!");
            return;
        }

        ResetRound();
    }


    void UpdateUI()
    {
    if(leftHealthText != null)
        leftHealthText.text = leftHealth.ToString();

    if(rightHealthText != null)
        rightHealthText.text = rightHealth.ToString();
    }

    void ResetRound()
    {
    BallMovement ball = FindAnyObjectByType<BallMovement>();

    ball.transform.position = Vector3.zero;

    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

    rb.linearVelocity = Vector2.zero;

    ball.Launch();
    }


    void EndBattle(string message)
    {
    Time.timeScale = 0f;

    if (battleWinPanel != null)
    {
        battleWinPanel.SetActive(true);
    }

    if (winnerText != null)
    {
        winnerText.text = message;
    }

    Debug.Log(message);
    }
}
