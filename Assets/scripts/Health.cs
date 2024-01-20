using System.Collections;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int points = 1;
    private float invincibilityTime = 0.1f;
    private bool isInvincible = false;

    [SerializeField]
    private TextMeshProUGUI playerHealthText; // Reference to the TextMeshProUGUI component for player health

    [SerializeField]
    private TextMeshProUGUI staticSpriteText; // Reference to the TextMeshProUGUI component for static sprite

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") && isInvincible == false)
        {
            points--;
            StartCoroutine(Invincibility());
            Destroy(other.gameObject);

            if (gameObject.CompareTag("Player"))
            {
                UpdatePlayerHealthText();
            }
            else if (gameObject.CompareTag("StaticSprite"))
            {
                UpdateStaticSpriteHealthText();
            }
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

    void UpdatePlayerHealthText()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = "Player Health: " + points.ToString();
        }
    }

    void UpdateStaticSpriteHealthText()
    {
        if (staticSpriteText != null)
        {
            staticSpriteText.text = "Base Health: " + points.ToString();
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
