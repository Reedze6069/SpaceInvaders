using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int points = 1;
    private float invincibilityTime = 0.1f;
    private bool isInvincible = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") && isInvincible == false)
        {
            points--;
            StartCoroutine(Invincibility());
            Destroy(other.gameObject);
        }

        if (points <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}