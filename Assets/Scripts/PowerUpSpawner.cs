using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Power-Ups")]
    public GameObject longPaddlePowerUp;
    public GameObject speedBoostPowerUp;
    public GameObject shrinkOpponentPowerUp;


    [Header("Spawn Settings")]
    public float spawnInterval = 6f;

    public float minX = -2f;
    public float maxX = 2f;

    public float minY = -3.5f;
    public float maxY = 3.5f;


    private GameObject currentPowerUp;

    private GameObject lastPowerUp;


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
        // If a power-up is already on the field, wait
        if (currentPowerUp != null)
            return;


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


        lastPowerUp = prefab;


        Debug.Log("Spawned Power-Up: " + prefab.name);
    }



    GameObject GetRandomPowerUp()
{
    bool angelActive = false;

    if (GameModeManager.Instance != null)
    {
        angelActive = GameModeManager.Instance.AngelModeActive;
    }


    // Better comeback chances during Angel Mode
    if (angelActive)
    {
        int roll = Random.Range(0, 100);

        if (roll < 50)
        {
            return longPaddlePowerUp;
        }
        else if (roll < 90)
        {
            return speedBoostPowerUp;
        }
        else
        {
            return shrinkOpponentPowerUp;
        }
    }


    // Normal random spawning
    int normalRoll = Random.Range(0, 3);

    switch (normalRoll)
    {
        case 0:
            return longPaddlePowerUp;

        case 1:
            return speedBoostPowerUp;

        default:
            return shrinkOpponentPowerUp;
    }
}



    // Called by power-ups when collected
    public void PowerUpCollected()
    {
        currentPowerUp = null;
    }
}