using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float shiftDistance = 1f;
    [SerializeField]
    private Transform target; // The target (player cube) that enemies move towards

    private GameObject cubeController; // Reference to the CubeController script, not exposed since it's set internally

    [SerializeField]
    private float minShootInterval = 2f;
    [SerializeField]
    private float maxShootInterval = 5f;
    private float shootTimer; // Timer to track when the enemy should shoot

    [SerializeField]
    private GameObject enemyProjectilePrefab; // Reference to the enemy projectile prefab
    [SerializeField]
    private float yOffset = 0.5f;

    void Start()
    {
        // Attempt to find the player cube if not set
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Initialize the shoot timer randomly
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsPlayer();
            HandleShooting();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 directionToPlayer = (target.position - transform.position).normalized;
        Vector3 shiftedPosition = transform.position + Vector3.right * Mathf.Sin(Time.time * 2f) * shiftDistance;
        transform.position = Vector3.MoveTowards(transform.position, shiftedPosition, moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            shootTimer = Random.Range(minShootInterval, maxShootInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 projectilePosition = transform.position + new Vector3(0f, yOffset, 0f);
        Instantiate(enemyProjectilePrefab, projectilePosition, Quaternion.Euler(0, 0, 180f));
    }

    public void DestroyEnemy()
    {
        if (cubeController != null)
        {
            cubeController.GetComponent<CubeController>().EnemyDestroyed();
            cubeController.GetComponent<CubeController>().ReturnProjectile();
        }
        Destroy(gameObject);
    }
}