using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public Transform[] spawnPoints;

    private float timeElapsed = 0f;
    private float increaseSpawnRateInterval = 10f; // Increase spawn rate every 10 seconds

    void Start()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            InvokeRepeating("SpawnEnemy", 0f, Random.Range(minSpawnDelay, maxSpawnDelay));
        }
        else
        {
            Debug.LogError("No valid spawn points assigned to the EnemySpawner.");
        }
    }

    void Update()
    {
        // Increment the time elapsed
        timeElapsed += Time.deltaTime;

        // Check if it's time to increase spawn rate
        if (timeElapsed >= increaseSpawnRateInterval)
        {
            IncreaseSpawnRate();
            timeElapsed = 0f; // Reset the timer
        }
    }

    void IncreaseSpawnRate()
    {
        // Decrease minSpawnDelay and maxSpawnDelay to make enemies spawn faster
        minSpawnDelay = Mathf.Max(minSpawnDelay - 0.1f, 0.1f);
        maxSpawnDelay = Mathf.Max(maxSpawnDelay - 0.1f, 0.1f);
        Debug.Log($"Spawn rate increased. minSpawnDelay: {minSpawnDelay}, maxSpawnDelay: {maxSpawnDelay}");
    }

    void SpawnEnemy()
    {
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("No valid spawn points available for enemy spawning.");
        }
    }
}