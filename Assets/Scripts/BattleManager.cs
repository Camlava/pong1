using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public int maxHealth = 5;

    public bool leftShieldActive;
    public bool rightShieldActive;

    public bool leftDamageBoost;
    public bool rightDamageBoost;
    public int leftHealth;
    public int rightHealth;


    [Header("Health UI")]
    public TextMeshProUGUI leftHealthText;
    public TextMeshProUGUI rightHealthText;

    public string fullHeart = "♥";
public string emptyHeart = "-";


    [Header("Battle UI")]
    public GameObject battleUI;

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


        // Only show Battle UI in Battle Mode
        if (battleUI != null)
        {
            battleUI.SetActive(ScoreSettings.battleMode);
        }


        UpdateUI();
    }



   public void DamageLeft()
{
    if(leftShieldActive)
    {
        leftShieldActive = false;
        ResetRound();
        return;
    }


    if(leftDamageBoost)
    {
        leftHealth -= 2;
        leftDamageBoost = false;
    }
    else
    {
        leftHealth--;
    }


    leftHealth = Mathf.Max(leftHealth, 0);

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
    if(rightShieldActive)
    {
        rightShieldActive = false;
        ResetRound();
        return;
    }


    if(rightDamageBoost)
    {
        rightHealth -= 2;
        rightDamageBoost = false;
    }
    else
    {
        rightHealth--;
    }


    rightHealth = Mathf.Max(rightHealth, 0);

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
    {
        leftHealthText.text = "LEFT " + leftHealth;
    }

    if(rightHealthText != null)
    {
        rightHealthText.text = "RIGHT " + rightHealth;
    }
}


    string CreateHealthBar(int health)
    {
        string hearts = "";


        for(int i = 0; i < maxHealth; i++)
        {
            if(i < health)
                hearts += fullHeart;
            else
                hearts += emptyHeart;
        }


        return hearts;
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

    public void HealLeft(int amount)
{
    Debug.Log("Before Heal Left: " + leftHealth + " / " + rightHealth);

    if(leftHealth > 0)
{
    leftHealth += amount;
}

    if(leftHealth > maxHealth)
        leftHealth = maxHealth;

    Debug.Log("After Heal Left: " + leftHealth + " / " + rightHealth);

    UpdateUI();
}


public void HealRight(int amount)
{
    Debug.Log("Before Heal Right: " + leftHealth + " / " + rightHealth);

    if(rightHealth > 0)
{
    rightHealth += amount;
}

    if(rightHealth > maxHealth)
        rightHealth = maxHealth;

    Debug.Log("After Heal Right: " + leftHealth + " / " + rightHealth);

    UpdateUI();
}

public void ActivateShield(bool leftPlayer)
{
    if(leftPlayer)
    {
        leftShieldActive = true;
        Debug.Log("Left Player Shield Activated!");
    }
    else
    {
        rightShieldActive = true;
        Debug.Log("Right Player Shield Activated!");
    }
}

public void ActivateDamageBoost(bool leftPlayer)
{
    if(leftPlayer)
    {
        leftDamageBoost = true;
        Debug.Log("Left Player Damage Boost Activated!");
    }
    else
    {
        rightDamageBoost = true;
        Debug.Log("Right Player Damage Boost Activated!");
    }
}
}
