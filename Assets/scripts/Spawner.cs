using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Transform[] spawnPoints;

    private float increaseSpawnRateInterval = 10f; // Interval to increase spawn rate

    public GameObject EnemyPrefab
    {
        get => enemyPrefab;
        private set => enemyPrefab = value;
    }

    public float MinSpawnDelay
    {
        get => minSpawnDelay;
        set => minSpawnDelay = Mathf.Max(0.1f, value); // Ensure spawn delay can't go below 0.1
    }

    public float MaxSpawnDelay
    {
        get => maxSpawnDelay;
        set => maxSpawnDelay = Mathf.Max(minSpawnDelay, value); // Ensure max is always >= min
    }

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
            MinSpawnDelay -= 0.1f;
            MaxSpawnDelay -= 0.1f;
            Debug.Log($"Spawn rate increased. MinSpawnDelay: {MinSpawnDelay}, MaxSpawnDelay: {MaxSpawnDelay}");
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
