using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float shiftDistance = 1f;
    public Transform target; // The target (player cube) that enemies move towards
    public GameObject cubeController; // Reference to the CubeController script

    public float minShootInterval = 2f; // Minimum time between shots
    public float maxShootInterval = 5f; // Maximum time between shots
    private float shootTimer; // Timer to track when the enemy should shoot

    public GameObject enemyProjectilePrefab; // Reference to the enemy projectile prefab
    public float yOffset = 0.5f; // Adjust the offset value as needed

    void Start()
    {
        // Set the target to the player cube
        if (cubeController == null)
        {
            cubeController = GameObject.FindGameObjectWithTag("Player");
        }

        // Initialize the shoot timer randomly
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    void Update()
    {
        MoveTowardsPlayer();

        // Update the shoot timer
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            // Reset the timer for the next shot
            shootTimer = Random.Range(minShootInterval, maxShootInterval);

            // Call a method to handle shooting
            Shoot();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector3 directionToPlayer = (target.position - transform.position).normalized;

        // Calculate a slightly shifted position to create side-to-side movement
        Vector3 shiftedPosition = transform.position + Vector3.right * Mathf.Sin(Time.time * 2f) * shiftDistance;

        // Move towards the shifted position
        transform.position = Vector3.MoveTowards(transform.position, shiftedPosition, moveSpeed * Time.deltaTime);

        // Move closer to the player
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    void Shoot()
    {
        // Instantiate an enemy projectile with an offset on the Y-axis
        Vector3 projectilePosition = transform.position + new Vector3(0f, yOffset, 0f);
        Quaternion rotation = Quaternion.Euler(0, 0, 180f);
        Instantiate(enemyProjectilePrefab, projectilePosition, rotation);
    }

    public void DestroyEnemy()
    {
        // Notify CubeController that an enemy is destroyed
        if (cubeController != null)
        {
            cubeController.GetComponent<CubeController>().EnemyDestroyed();

            // Return a projectile to the player
            cubeController.GetComponent<CubeController>().ReturnProjectile();
        }

        // Handle enemy destruction (e.g., play destruction animation, spawn particles, etc.)
        Destroy(gameObject);
    }
}

