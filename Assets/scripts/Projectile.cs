using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;

    private Rigidbody2D rb;

    void Awake()
    {
        // Cache the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the projectile!", this);
        }
    }

    void Start()
    {
        // Set the initial velocity of the projectile
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }
    }

    void OnBecameInvisible()
    {
        // Remove the projectile from the hierarchy when it becomes invisible
        Destroy(gameObject);
    }
}
