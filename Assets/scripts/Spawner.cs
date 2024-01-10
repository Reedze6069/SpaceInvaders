using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public Transform[] spawnPoints;

    void Start()
    {
        // Check if there are valid spawn points before invoking the SpawnEnemy method
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            // Invoke the SpawnEnemy method repeatedly with a random delay between minSpawnDelay and maxSpawnDelay
            InvokeRepeating("SpawnEnemy", 0f, Random.Range(minSpawnDelay, maxSpawnDelay));
        }
        else
        {
            Debug.LogError("No valid spawn points assigned to the EnemySpawner.");
        }
    }

    void SpawnEnemy()
    {
        // Check if there are valid spawn points before attempting to access the array
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            // Randomly select a spawn point from the array
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the enemy prefab at the chosen spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("No valid spawn points available for enemy spawning.");
        }
    }
}