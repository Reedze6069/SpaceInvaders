using UnityEngine;
using System.Collections;

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
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No valid spawn points assigned to the EnemySpawner.");
            return;
        }
        StartCoroutine(SpawnEnemies());
        StartCoroutine(AdjustSpawnRate());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }

    IEnumerator AdjustSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseSpawnRateInterval);
            // Adjust the spawn rates after the specified interval
            minSpawnDelay = Mathf.Max(minSpawnDelay - 0.1f, 0.1f);
            maxSpawnDelay = Mathf.Max(maxSpawnDelay - 0.1f, 0.1f);
            Debug.Log($"Spawn rate increased. minSpawnDelay: {minSpawnDelay}, maxSpawnDelay: {maxSpawnDelay}");
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
