using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Power-Ups")]
    public GameObject longPaddlePowerUp;
    public GameObject speedBoostPowerUp;
    public GameObject shrinkOpponentPowerUp;

    // Battle Power-Ups
    public GameObject healPowerUp;
    public GameObject shieldPowerUp;
    public GameObject damageBoostPowerUp;
    public GameObject rageModePowerUp;


    [Header("Spawn Settings")]
    public float spawnInterval = 6f;

    public float minX = -2f;
    public float maxX = 2f;

    public float minY = -3.5f;
    public float maxY = 3.5f;


    private GameObject currentPowerUp;


    void Start()
    {
        SpawnPowerUp();

        InvokeRepeating(
            nameof(SpawnPowerUp),
            spawnInterval,
            spawnInterval
        );
    }



   void SpawnPowerUp()
{
    if (currentPowerUp != null)
    {
        // Check if Unity destroyed it
        if (currentPowerUp == null)
        {
            currentPowerUp = null;
        }
        else
        {
            return;
        }
    }


    GameObject prefab = GetRandomPowerUp();


    Vector2 spawnPos = new Vector2(
        Random.Range(minX, maxX),
        Random.Range(minY, maxY)
    );


    currentPowerUp = Instantiate(
        prefab,
        spawnPos,
        Quaternion.identity
    );


    Debug.Log("Spawned Power-Up: " + prefab.name);
}



    GameObject GetRandomPowerUp()
{
    bool angelActive = false;

    if (GameModeManager.Instance != null)
    {
        angelActive = GameModeManager.Instance.AngelModeActive;
    }


    // Angel Mode = better comeback power-ups
    if (angelActive)
    {
        int roll = Random.Range(0, 100);


        if (roll < 35)
            return healPowerUp;

        if (roll < 55)
            return shieldPowerUp;

        if (roll < 75)
            return longPaddlePowerUp;

        if (roll < 90)
            return speedBoostPowerUp;

        return rageModePowerUp;
    }



    // BATTLE MODE POWER-UPS
    if (ScoreSettings.battleMode)
    {
        int battleRoll = Random.Range(0, 7);


        switch (battleRoll)
        {
            case 0:
                return longPaddlePowerUp;

            case 1:
                return speedBoostPowerUp;

            case 2:
                return shrinkOpponentPowerUp;

            case 3:
                return healPowerUp;

            case 4:
                return shieldPowerUp;

            case 5:
                return damageBoostPowerUp;

            case 6:
                return rageModePowerUp;
        }
    }



    // NORMAL PONG POWER-UPS ONLY
    int normalRoll = Random.Range(0, 3);


    switch(normalRoll)
    {
        case 0:
            return longPaddlePowerUp;

        case 1:
            return speedBoostPowerUp;

        case 2:
            return shrinkOpponentPowerUp;
    }


    return longPaddlePowerUp;
}



    public void PowerUpCollected()
    {
        currentPowerUp = null;
    }
}