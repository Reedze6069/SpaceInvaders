using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Start()
    {
        // Move the projectile using Rigidbody2D
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnBecameInvisible()
    {
        // Remove the projectile from the hierarchy when it becomes invisible
        Destroy(gameObject);
    }
}