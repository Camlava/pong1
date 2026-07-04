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

    void Start()
    {
        SpawnPowerUp();
        InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
    }

    void SpawnPowerUp()
    {
        if (currentPowerUp != null)
        {
            // auto-clean if it got destroyed but reference still exists
            if (currentPowerUp == null)
                currentPowerUp = null;
            else
                return;
        }

        GameObject prefab = GetRandomPowerUp();

        Vector2 spawnPos = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        currentPowerUp = Instantiate(prefab, spawnPos, Quaternion.identity);

        Debug.Log("Spawned: " + prefab.name + " at " + spawnPos);
    }

    GameObject GetRandomPowerUp()
    {
        int roll = Random.Range(0, 3);

        switch (roll)
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
}