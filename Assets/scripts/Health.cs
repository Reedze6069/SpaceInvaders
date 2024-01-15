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
            // Check if the object is the player or static sprite
            if (gameObject.CompareTag("Player") || gameObject.CompareTag("StaticSprite"))
            {
                StartCoroutine(GameOver());
            }
            else
            {
                Destroy(gameObject); // Destroy enemies
            }
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over!");
        // You can add more game over logic here if needed
        Time.timeScale = 0f; // Pause the game
        yield return null;
    }
}